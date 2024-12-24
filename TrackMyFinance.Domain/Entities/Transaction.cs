using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyFinance.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        
        //Type
        public Guid TypeId { get; set; }
        public Type Type { get; set; }

        //User
        public Guid UserId { get; set; }
        public User User { get; set; }

        //Category
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
