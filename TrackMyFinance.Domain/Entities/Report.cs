using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyFinance.Domain.Entities
{
    public class Report : BaseEntity
    {
        public string Month { get; set; }
        public int Year { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpende { get; set; }
        public decimal RemainingBudget { get; set; }

        //User
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
