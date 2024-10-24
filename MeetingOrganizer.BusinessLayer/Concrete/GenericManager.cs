using MeetingOrganizer.BusinessLayer.Abstract;
using MeetingOrganizer.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingOrganizer.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public GenericManager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void TCreate(T entity)
        {
            _repository.Create(entity);
        }

        public void TDelete(int id)
        {
            _repository.Delete(id);
        }

        public List<T> TGetList()
        {
           return _repository.GetList();
        }

        public T TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public void TUpdate(T entity)
        {
            _repository.Update(entity);
        }
    }
}
