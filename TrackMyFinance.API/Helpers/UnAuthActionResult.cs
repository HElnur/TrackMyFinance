using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TrackMyFinance.API.Helpers
{
    public class UnAuthResult
    {
        public int StatusCode { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string>? Errors { get; set; }
    }

    public class UnAuthActionResult : ObjectResult
    {
        public UnAuthActionResult(string description = "Bu əməliyyatın icrası üçün hüququnuz yoxdur.", Dictionary<string, string>? errors = null)
            : base(new UnAuthResult
            {
                StatusCode = (int)HttpStatusCode.Unauthorized,
                Description = description,
                Errors = errors
            })
        {
            StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
