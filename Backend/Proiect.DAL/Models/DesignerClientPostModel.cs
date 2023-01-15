using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Models
{
    public class DesignerClientPostModel
    {
        public int Id { get; set; }
        public int DesignerId { get; set; }
        public int ClientId { get; set; }
    }
}
