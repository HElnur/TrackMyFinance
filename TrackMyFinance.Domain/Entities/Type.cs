using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyFinance.Domain.Entities
{
    public class Type : BaseEntity
    {
        public string Name { get; set; }

        //Transactions
        public ICollection<Transaction> Transactions { get; set; }
    }
}
