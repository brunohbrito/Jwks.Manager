using Microsoft.Extensions.DependencyInjection;

namespace NetDevPack.Security.Jwt.Tests.Warmups
{
    public interface IWarmupTest
    {
        ServiceProvider Services { get; set; }
        void Clear();
    }
}