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
        // public static IEnumerable<ApiResource> ApiResources =>
        //     new List<ApiResource>
        //     {
        //         new ApiResource("api.read", "Demo API")
        //         {
        //             ApiSecrets = { new Secret("secret".Sha256()) },
        //             Scopes = { "api.read" }
        //         }
        //     };

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
                        RedirectUris = {
                                            "https://rc-auth-app.herokuapp.com/authentication/login-callback",
                                            "https://localhost:44343/authentication/login-callback",
                                            "https://localhost:5001/authentication/login-callback"
                                        },
                        PostLogoutRedirectUris = {
                                            "https://rc-auth-app.herokuapp.com/authentication/logout-callback",
                                            "https://localhost:44343/authentication/logout-callback",
                                            "https://localhost:5001/authentication/logout-callback"
                                        },
                        AllowedCorsOrigins = {
                                            "https://rc-auth-app.herokuapp.com",
                                            "https://localhost:44343",
                                            "https://localhost:5001"
                                        },
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
