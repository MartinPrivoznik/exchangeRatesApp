using System;
using System.Collections.Generic;
using System.Text;

namespace firstTry.ViewModel.ItemViewModels
{
    class Item
    {
        public bool success { get; set; }
        public string terms { get; set; }
        public string privaty { get; set; }
        public float timestamp { get; set; }
        public string source { get; set; }
        public Dictionary<string, double> quotes { get; set; } 
    }
}
