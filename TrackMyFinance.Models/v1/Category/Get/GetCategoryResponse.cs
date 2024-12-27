using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyFinance.Models.v1.Category.Get
{
    public class GetCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public string CreateAt { get; set; }
        public string UpdateAt { get; set; }
    }
}
