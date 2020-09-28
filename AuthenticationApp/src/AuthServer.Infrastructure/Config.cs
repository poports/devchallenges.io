using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace AuthServer.Infrastructure
{
 
        public static class Config
        {
            public static IEnumerable<IdentityResource> IdentityResources =>
                new List<IdentityResource>
                {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                };


            public static IEnumerable<ApiScope> ApiScopes =>
                new List<ApiScope>
                {
                new ApiScope("api.read", "AuthenticationApp")
                };

            public static IEnumerable<Client> Clients =>
                new List<Client>
                {

                // JavaScript Client
                    new Client
                    {
                        ClientId = "AuthenticationApp",
                        ClientName = "JavaScript Client",
                        AllowedGrantTypes = GrantTypes.Code,
                        RequireClientSecret = false,

                        RedirectUris =           { "https://localhost:44343/authentication/login-callback" },
                        PostLogoutRedirectUris = { "https://localhost:44343/authentication/logout-callback" },
                        AllowedCorsOrigins =     { "https://localhost:44343" },

                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "api.read"
                        }
                    }
                };
        }
    }
