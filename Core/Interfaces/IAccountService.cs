using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;

namespace Core.Interfaces
{
    public interface IAccountService
    {
        Task<string> CreateToken(Customer user);
    }
}