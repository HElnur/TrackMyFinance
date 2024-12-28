using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyFinance.Application.Interfaces
{
    public interface IJWTService
    {
        public string GenerateJwtToken<TOutput>(TOutput user);
        public string ValidateJwtToken { get; set; }
    }
}
