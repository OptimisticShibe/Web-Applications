﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningWebsite.Models
{
    public class ClassOfferingsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public ClassOfferingsModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}