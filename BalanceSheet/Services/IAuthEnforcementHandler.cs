using System.Threading.Tasks;

namespace BalanceSheet.Services
{
    public interface IAuthEnforcementHandler
    {
        Task CheckUserAuthentification();
    }
}