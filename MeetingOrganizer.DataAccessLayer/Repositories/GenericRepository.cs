using MeetingOrganizer.DataAccessLayer.Abstract;
using MeetingOrganizer.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly MeetingOrganizerContext _context;

        public GenericRepository(MeetingOrganizerContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }

        public List<T> GetList()
        {
           return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
