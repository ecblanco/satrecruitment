using Sat.Recruitment.Api.Models;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services.Interfaces
{
    public interface IUserService
    {
        Result CreateNewUser(string name, string email, string address, string phone, string userType, string money);
    }
}
