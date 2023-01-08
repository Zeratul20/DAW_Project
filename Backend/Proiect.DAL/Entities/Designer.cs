using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Entities
{
    public class Designer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public virtual DesignerAddress DesignerAddress { get; set; } // 1:1
        public virtual ICollection<DesignerClient> DesignerClients { get; set; } // " M : M "
    }
}
