using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasNFc.Models
{
    public class NFc
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Serie { get; set; }
        public string QrCode { get; set; }

        public string NumeroSerie => $"{Numero}-{Serie}";
    }
}
