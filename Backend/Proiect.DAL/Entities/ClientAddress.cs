using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Entities
{
    public class ClientAddress
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; } // 1 : 1
    }
}
