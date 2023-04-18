using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSample.Domain.Service.Core
{
    public abstract class BaseEntity<T>:IEntity<T> 
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public interface IEntity<T>
    {
        T Id { get; }
    }
}
