using Lets_Share.Models;
using System.Collections.Generic;
using System.Linq;

namespace LetsRsvp.Models
{
    public class Repositorio : IRepositorio
    {
        private readonly AppDbContext _context;

        public Repositorio(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<AddItem> ItemSet { get => _context.ItemSet; }

        public void Add(AddItem item)
        {

            _context.ItemSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(AddItem item)
        {

            _context.ItemSet.Update(item);
            _context.SaveChanges();
        }

        public void Remove(AddItem item)
        {
            _context.ItemSet.Remove(item);
            _context.SaveChanges();
        }
    }
}