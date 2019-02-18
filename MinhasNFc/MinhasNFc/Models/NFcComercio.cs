using MinhasNFc.Interfaces.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasNFc.Models
{
    public class NFcComercio : IStoreModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string Endereco { get; set; }

        public override string ToString()
        {
            return RazaoSocial;
        }
    }
}
