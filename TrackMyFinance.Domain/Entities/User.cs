using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace TrackMyFinance.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }

        //Reports
        public ICollection<Report> Reports { get; set; }

        //Transactions
        public ICollection<Transaction> Transactions { get; set; }
    }
}
