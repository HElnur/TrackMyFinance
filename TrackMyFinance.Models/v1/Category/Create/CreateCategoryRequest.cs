﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyFinance.Models.v1.Category.Create
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}