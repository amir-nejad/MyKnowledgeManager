using IdentityServer4.Models;
using Microsoft.AspNetCore.DataProtection;
using Secret = IdentityServer4.Models.Secret;

namespace MyKnowledgeManager.IdentityServer.IdentityConfiguration
{
    public static class ClientsConfiguration
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("929E5844-AF76-41BE-8F17-2FA426239E71".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44311/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44311/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44311/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile" }
                },
            };
    }

}
