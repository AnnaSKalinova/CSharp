using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;

        protected Repository()
        {
            this.models = new List<T>();
        }
        
        public void Add(T model)
        {
            this.models.Add(model);
        }

        public System.Collections.Generic.IReadOnlyCollection<T> GetAll()
        {
            return this.models.ToList();
        }

        public T GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.GetType().Name == name);
        }

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
