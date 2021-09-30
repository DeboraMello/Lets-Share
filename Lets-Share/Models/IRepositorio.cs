using Lets_Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsRsvp.Models
{
    public interface IRepositorio
    {
        IQueryable<AddItem> ItemSet { get; }

        void AddOrUpdate(AddItem item);
        void Remove(AddItem item);
    }
}
