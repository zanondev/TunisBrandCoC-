using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TunisBrandCo.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public Decimal LoyaltyPoints { get; set; }

        public Client(int id, string name, int cpf, DateTime birthDate, decimal loyaltyPoints)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;
            LoyaltyPoints = loyaltyPoints;
        }
    }
}
