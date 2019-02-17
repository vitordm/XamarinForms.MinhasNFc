using System;
using System.Collections.Generic;
using SQLite;

using MinhasNFc.Interfaces.Models;
using SQLiteNetExtensions.Attributes;

namespace MinhasNFc.Models
{
    public class NFc : IStoreModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Serie { get; set; }
        public DateTime DataNFc { get; set; }
        public double ValorTotal { get; set; }
        public double ValorDescontos { get; set; }
        public string FormaPagamento { get; set; }
        public double? ValorPago { get; set; }
        public bool ConsumidorIdentificado { get; set; }
        public string DocumentoConsumidor { get; set; }
        public int ComercioId { get; set; }

        [SQLite.Ignore]
        public NFcComercio Comercio { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public IList<NFcItem> Itens { get; set; }

        public string NumeroSerie => $"{Numero}-{Serie}";

        public NFc()
        {
            Itens = new List<NFcItem>();
        }
    }
}
