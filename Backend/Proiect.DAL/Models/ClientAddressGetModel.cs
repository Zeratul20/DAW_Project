using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Models
{
    public class ClientAddressGetModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public int ClientId { get; set; }

        public static Expression<Func<Entities.ClientAddress, ClientAddressGetModel>> Projection => address => new ClientAddressGetModel()
        {
            Id = address.Id,
            City = address.City,
            Zipcode = address.Zipcode,
            ClientId = address.ClientId
        };
    }
}
