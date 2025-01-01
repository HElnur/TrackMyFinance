using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyFinance.Models.v1.Type.Update
{
    public class UpdateTypeRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
