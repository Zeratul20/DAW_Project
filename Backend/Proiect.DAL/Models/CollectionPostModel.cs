using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Models
{
    public class CollectionPostModel
    {
        public int Id { get; set; }
        public string CollectionName { get; set; }
        public int NumberOfItems { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}