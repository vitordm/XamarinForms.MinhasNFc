using MinhasNFc.Interfaces.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasNFc.Models
{
    public class NFcItem : IStoreModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public double Qtde { get; set; }
        public string Un { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }
        [ForeignKey(typeof(NFc))]
        public int NFcId { get; set; }
    }
}
