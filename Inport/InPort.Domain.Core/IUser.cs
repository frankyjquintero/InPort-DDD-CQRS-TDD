using System.Collections.Generic;
using System.Security.Claims;

namespace InPort.Domain.Core
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
