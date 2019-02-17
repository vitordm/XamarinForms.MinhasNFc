using MinhasNFc.Interfaces.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace MinhasNFc.Models
{
    public class Item : IStoreModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string QrCode { get; set; }
        public bool Sincronizado { get; set; }
        public DateTime CriadoEm { get; set; }
        [ForeignKey(typeof(NFc))]
        public int? NFcId { get; set; }

        public string CriadoEmFormat => CriadoEm.ToString("dd/MM/yyyy HH:mm");
    }
}