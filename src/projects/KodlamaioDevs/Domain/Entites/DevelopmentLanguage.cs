﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class DevelopmentLanguage :Entity
    {

        public string Name { get; set; }

        public DevelopmentLanguage()
        {


        }


        public DevelopmentLanguage (int id, string name):this()
        {   
            Id = id;
            Name = name;
            
        }

    }
}
