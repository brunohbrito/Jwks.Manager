using NetDevPack.Security.JwtSigningCredentials.Model;

namespace NetDevPack.Security.JwtSigningCredentials.Jwks
{
    public class JwkContants
    {
        public static string CurrentJwkCache(JsonWebKeyType jwkType) => $"NETDEVPACK-CURRENT-{jwkType}-SECURITY-KEY";
        public const string JwksCache = "NETDEVPACK-JWKS";
    }
}