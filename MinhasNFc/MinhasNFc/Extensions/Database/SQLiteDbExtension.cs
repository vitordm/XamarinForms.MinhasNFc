using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasNFc.Extensions.Database
{
    public static class SQLiteDbExtension
    {

        public static bool TabelaExiste<T>(this SQLiteConnection connection)
        {
            var tableName = typeof(T).Name;
            return connection.TabelaExiste(tableName);
        }

        public static bool TabelaExiste(this SQLiteConnection connection, string tableName)
        {
            //SQLite.TableMapping map = new TableMapping(typeof(SQLiteConnection)); // Instead of mapping to a specific table just map the whole database type
            //object[] ps = new object[0]; // An empty parameters object since I never worked out how to use it properly! (At least I'm honest)

            //Int32 tableCount = GetConnection().Query(map, "SELECT * FROM sqlite_master WHERE type = 'table' AND name = '" + tableName + "'", ps).Count; // Executes the query from which we can count the results
            //Int32 tableCount = GetConnection().Query();

            var tableCount = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = '" + tableName + "'");

            if (tableCount == 0)
            {
                return false;
            }
            else if (tableCount == 1)
            {
                return true;
            }
            else
            {
                throw new Exception("More than one table by the name of " + tableName + " exists in the database.", null);
            }
        }

        public static void CriarTabela<T>(this SQLiteConnection connection)
        {
            
                connection.CreateTable<T>();
        }

        public static bool VerificarSeColunasExistes<T>(this SQLiteConnection connection, IList<string> columns, out IList<string> columnsNotExists)
        {
            using (connection)
            {

                Type typeParameterType = typeof(T);
                var table = typeParameterType.Name;
                var colunas = connection.ExecutarSql($"PRAGMA table_info({table})");

                columnsNotExists = new List<string>();

                var columnsExists = new List<string>();

                foreach (var col in colunas)
                {
                    var columnName = (string)col["name"];
                    columnsExists.Add(columnName);
                }

                foreach (var col in columns)
                {
                    if (!columnsExists.Contains(col))
                    {
                        columnsNotExists.Add(col);
                    }
                }
                return !(columnsNotExists.Count > 0);
            }
        }

        public static void CriarColuna<T>(this SQLiteConnection connection, string column, string type)
        {
            connection.CriarColuna<T>(column, type, true);
        }

        public static void CriarColuna<T>(this SQLiteConnection connection, string column, string type, bool isNull = true)
        {
            using (connection)
            {
                Type typeParameterType = typeof(T);
                var table = typeParameterType.Name;
                var nulo = (isNull) ? "NULL" : "NOT NULL";
                var query = connection.CreateCommand($"ALTER TABLE {table} ADD {column} {type} {nulo}");
                query.ExecuteNonQuery();
            }
        }

        public static void CriarColuna<T>(this SQLiteConnection connection, string column, string type, bool isNull = true, string defaultValue = "")
        {
            using (connection)
            {
                Type typeParameterType = typeof(T);
                var table = typeParameterType.Name;
                var nulo = (isNull) ? "NULL" : "NOT NULL";
                var query = connection.CreateCommand($"ALTER TABLE {table} ADD {column} {type} {nulo} DEFAULT {defaultValue}");
                query.ExecuteNonQuery();
            }
        }

        public static IList<IDictionary<string, object>> ExecutarSql(this SQLiteConnection connection, string sqlString)
        {

            var result = new List<IDictionary<string, object>>();
            SQLitePCL.sqlite3_stmt stQuery = null;

            using (connection)
            {
                using (stQuery = SQLite3.Prepare2(connection.Handle, sqlString))
                {
                    var colunas = stQuery.GetColunasSQLite();

                    while (SQLite3.Step(stQuery) == SQLite3.Result.Row)
                    {
                        var linha = stQuery.ParseSQLiteLinha(colunas);

                        result.Add(linha);

                    }

                }
            }

            return result;

        }

        public static void ExecutaSql(SQLiteConnection conn, string sqlString, Func<IDictionary<string, object>, bool> action)
        {
            SQLitePCL.sqlite3_stmt stQuery = null;
            using (stQuery = SQLite3.Prepare2(conn.Handle, sqlString))
            {
                var colunas = stQuery.GetColunasSQLite();

                while (SQLite3.Step(stQuery) == SQLite3.Result.Row)
                {
                    var linha = ParseSQLiteLinha(stQuery, colunas);
                    if (!action(linha))
                    {
                        break;
                    }
                }
            }
        }

        public static string[] GetColunasSQLite(this SQLitePCL.sqlite3_stmt stQuery)
        {
            var qtdColunas = SQLite3.ColumnCount(stQuery);
            var colunas = new string[qtdColunas];
            for (int i = 0; i < qtdColunas; i++)
            {
                colunas[i] = SQLite3.ColumnName(stQuery, i);
            }

            return colunas;
        }

        public static IDictionary<string, object> ParseSQLiteLinha(this SQLitePCL.sqlite3_stmt stQuery, string[] colunas)
        {
            var linha = new Dictionary<string, object>();

            for (int i = 0; i < colunas.Length; i++)
            {
                var coluna = colunas[i];
                var tipoColuna = SQLite3.ColumnType(stQuery, i);
                switch (tipoColuna)
                {

                    case SQLite3.ColType.Blob:

                        linha.Add(coluna, SQLite3.ColumnBlob(stQuery, i));
                        break;
                    case SQLite3.ColType.Float:
                        linha.Add(coluna, SQLite3.ColumnDouble(stQuery, i));
                        break;
                    case SQLite3.ColType.Integer:
                        linha.Add(coluna, SQLite3.ColumnInt(stQuery, i));
                        break;
                    case SQLite3.ColType.Null:
                        linha.Add(coluna, null);
                        break;
                    case SQLite3.ColType.Text:
                        linha.Add(coluna, SQLite3.ColumnString(stQuery, i));
                        break;
                }
            }

            return linha;
        }
    }
}
