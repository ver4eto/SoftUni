using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private List<T> entities;

        public IReadOnlyList<T> Entities
        {
            get
            {
                return this.entities.AsReadOnly();
            }
        }
        public void Add(T model)
        {
            this.entities.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Entities;
        }

        public T GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T model)
        {
            throw new NotImplementedException();
        }
    }
}
