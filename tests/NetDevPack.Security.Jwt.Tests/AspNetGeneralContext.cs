using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Security.Jwt.Model;
using NetDevPack.Security.Jwt.Store.EntityFrameworkCore;

namespace NetDevPack.Security.Jwt.Tests
{
    public class AspNetGeneralContext : DbContext, IDataProtectionKeyContext, ISecurityKeyContext
    {
        public AspNetGeneralContext(DbContextOptions<AspNetGeneralContext> options)
            : base(options) { }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
        public DbSet<SecurityKeyWithPrivate> SecurityKeys { get; set; }
    }
}
