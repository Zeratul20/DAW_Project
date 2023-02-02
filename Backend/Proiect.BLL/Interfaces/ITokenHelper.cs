using Proiect.DAL.Entities;
using System.Threading.Tasks;

namespace Proiect.BLL.Interfaces
{
    public interface ITokenHelper
    {
        Task<string> CreateAccessToken(User _User);
    }
}
