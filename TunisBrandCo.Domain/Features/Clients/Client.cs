using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TunisBrandCo.Domain.Features.Clients
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public Decimal LoyaltyPoints { get; set; }

        public Client()
        {
         
        }

        public bool Validate()
        {
            if(string.IsNullOrEmpty(this.Name))
            {
                return false;
            }
            if (this.BirthDate > DateTime.Now)
            {
                return false;
            }
            if (this.Cpf.Length > 11)
            {
                return false;
            }

            return true;
        }
    }
}
