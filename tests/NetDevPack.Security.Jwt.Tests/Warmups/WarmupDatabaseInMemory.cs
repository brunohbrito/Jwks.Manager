using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Security.Jwt.Interfaces;
using NetDevPack.Security.Jwt.Store.EntityFrameworkCore;

namespace NetDevPack.Security.Jwt.Tests.Warmups
{
    /// <summary>
    /// 
    /// </summary>
    public class WarmupDatabaseInMemory : IWarmupTest
    {
        private readonly IJsonWebKeyStore _jsonWebKeyStore;
        public ServiceProvider Services { get; set; }

        public WarmupDatabaseInMemory()
        {
            var serviceCollection = new ServiceCollection();

            void DatabaseOptions(DbContextOptionsBuilder opt) => opt.UseInMemoryDatabase("Tests").EnableSensitiveDataLogging();

            serviceCollection.AddMemoryCache();
            serviceCollection.AddLogging();
            serviceCollection.AddDbContext<AspNetGeneralContext>(DatabaseOptions);

            serviceCollection.AddJwksManager(o =>
            {
                o.Jws = JwsAlgorithm.ES256;
                o.Jwe = JweAlgorithm.RsaOAEP.WithEncryption(Encryption.Aes128CbcHmacSha256);
            })
            .PersistKeysToDatabaseStore<AspNetGeneralContext>();
            Services = serviceCollection.BuildServiceProvider();
            _jsonWebKeyStore = Services.GetRequiredService<IJsonWebKeyStore>();
        }

        public void Clear()
        {
            _jsonWebKeyStore.Clear();
        }
        public void DetachAll()
        {

            var database = Services.GetService<AspNetGeneralContext>();
            foreach (var dbEntityEntry in database.ChangeTracker.Entries())
            {
                if (dbEntityEntry.Entity != null)
                {
                    dbEntityEntry.State = EntityState.Detached;
                }
            }

        }
    }
}
