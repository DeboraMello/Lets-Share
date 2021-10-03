using Lets_Share.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Lets_Share.ViewModels
{
    public class ItemsViewModel
    {
        public string Search { get; set; }
        public IEnumerable<AddItem> Items { get; set; }
        public AddItem Item { get; set; }
    }
}
