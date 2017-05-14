﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningWebsite.UserDatabase;

namespace LearningWebsite.Repository
{
    class DatabaseAccessor
    {
        private static readonly Entities entities;

        static DatabaseAccessor()
        {
            entities = new Entities();
            entities.Database.Connection.Open();
        }

        public static Entities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}