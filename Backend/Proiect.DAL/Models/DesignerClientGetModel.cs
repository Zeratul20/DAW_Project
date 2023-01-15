using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Models
{
    public class DesignerClientGetModel
    {
        public int Id { get; set; }
        public int DesignerId { get; set; }
        public int ClientId { get; set; }

        public static Expression<Func<Entities.DesignerClient, DesignerClientGetModel>> Projection => designer_client => new DesignerClientGetModel()
        {
            Id = designer_client.Id,
            DesignerId = designer_client.DesignerId,
            ClientId = designer_client.ClientId,
        };
    }
}
