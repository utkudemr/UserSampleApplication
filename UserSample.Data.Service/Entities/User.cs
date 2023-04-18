﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSample.Data.Service.Entities
{
    public class User:  BaseEntity<Guid>, IEntity{ 
        public long TCKNNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }


}
