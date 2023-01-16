using Proiect.BLL.Models;
using System.Threading.Tasks;

namespace Proiect.BLL.Interfaces
{
    public interface IAuthManager
    {
        Task<bool> Register(RegisterModel registerModel);
        Task<LoginResult> Login(LoginModel loginModel);
    }
}
