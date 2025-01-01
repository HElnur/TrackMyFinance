using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
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

        public void AddPassword(string password)
        {
            Guid guid = Guid.NewGuid();

            using(SHA256 sha256 = SHA256.Create())
            {
                var salt = sha256.ComputeHash(Encoding.UTF8.GetBytes(guid.ToString()));

                using(HMACSHA256 hmacsha256 = new HMACSHA256(salt))
                {
                    var buffer = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                    Salt = salt;
                    Password = buffer;
                }
            }
        }

        public bool Check(string password)
        {
            using(HMACSHA256 hmacsha256 = new HMACSHA256(Salt))
            {
                var buffer = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                return buffer.SequenceEqual(Password);
            }
        }
    }
}
