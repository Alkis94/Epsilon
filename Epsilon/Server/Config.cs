using IdentityServer4.Models;
using IdentityClient = IdentityServer4.Models.Client;

namespace Epsilon.Server
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources => new[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource
            {
                Name = "role",
                UserClaims = new List<string> { "role" }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new[]
        {
            new ApiScope("Epsilon.read"),
            new ApiScope("Epsilon.write")
        };

        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            new ApiResource("Epsilon")
            {
                Scopes = new List<string> { "Epsilon.read", "Epsilon.write" },
                ApiSecrets = new List<Secret> { new Secret("ScopeSecret".Sha256()) },
                UserClaims = new List<string> { "role" }
            }
        };

        public static IEnumerable<IdentityClient> Clients => new[]
        {
            new IdentityClient
            {
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret ("ClientSecret1".Sha256())},
                AllowedScopes = { "Epsilon.read", "Epsilon.write" }
            },

             new IdentityClient
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:5444/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:5444/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5444/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "CoffeeAPI.read" },
                    RequirePkce = true,
                    RequireConsent = true,
                    AllowPlainTextPkce = false
                },
        };

    }
}
