using Lets_Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lets_Share.ViewModels
{
    public class UsersViewModel
    {
        public string Search { get; set; }
        public IEnumerable<AddUser> Users { get; set; }
        public AddUser User { get; set; }
    }
}
