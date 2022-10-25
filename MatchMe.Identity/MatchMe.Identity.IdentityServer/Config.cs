using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System.Collections.Generic;

namespace MatchMe.Identity.IdentityServer
{
    public static class Config
    {
        private static string _secret;

        public static void SetSecret(string Secret)
        {
            _secret = Secret;   
        }
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("matchme", "Match Me Server"),
                new ApiScope("read", "Read Data"),
                new ApiScope("write", "Write Data"),
                new ApiScope("delete", "Delete Data"),
            };

        public static IEnumerable<Client> Clients =>
           new List<Client>
           {
                 new Client
                {
                    ClientId="credentials",
                    ClientSecrets= { new Secret(_secret.Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "matchme"
                    }
                },
                 new Client
                {
                    ClientId="mango",
                    ClientSecrets= { new Secret(_secret.Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris={ "https://localhost:7086/signin-oidc" },
                    PostLogoutRedirectUris={ "https://localhost:7086/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "matchme"
                    }
                }
           };
    }
}
