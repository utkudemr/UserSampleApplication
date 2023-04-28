using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSample.Domain.Service.Core
{

    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get;set; }    
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public bool IsActive { get; set; }
    }
    public interface IEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
