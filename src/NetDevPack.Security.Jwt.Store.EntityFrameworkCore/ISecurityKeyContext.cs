using Microsoft.EntityFrameworkCore;
using NetDevPack.Security.Jwt.Model;

namespace NetDevPack.Security.Jwt.Store.EntityFrameworkCore
{
    public interface ISecurityKeyContext
    {
        /// <summary>
        /// A collection of <see cref="T:NetDevPack.Security.JwtSigningCredentials.SecurityKeyWithPrivate" />
        /// </summary>
        DbSet<SecurityKeyWithPrivate> SecurityKeys { get; set; }
    }
}
