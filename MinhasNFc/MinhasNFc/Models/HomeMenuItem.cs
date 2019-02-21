using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasNFc.Models
{
    public enum MenuItemType
    {
        NFc,
        QrCodes,
        About,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
