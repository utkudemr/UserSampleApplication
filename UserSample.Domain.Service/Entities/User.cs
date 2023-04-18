using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSample.Domain.Service.Core;

namespace UserSample.Data.Service.Entities
{
    public class User:  BaseEntity<Guid>, IEntity<Guid>
    { 
        public long TCKNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }


}
