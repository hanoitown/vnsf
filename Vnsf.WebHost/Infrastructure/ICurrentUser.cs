using Vnsf.Data.Entities.Account;

namespace Vnsf.WebHost.Infrastructure
{
    public interface ICurrentUser
    {
        UserAccount User { get; } 
    }
}