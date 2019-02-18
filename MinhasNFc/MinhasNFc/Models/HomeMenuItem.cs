using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasNFc.Models
{
    public enum MenuItemType
    {
        Browse,
        NFc,
        About,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
