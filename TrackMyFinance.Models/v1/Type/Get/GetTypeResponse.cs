using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyFinance.Models.v1.Type.Get
{
    public class GetTypeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreateAt { get; set; }
        public string UpdateAt { get; set; }
    }
}
