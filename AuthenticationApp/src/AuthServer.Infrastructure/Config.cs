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
                                            $"{Environment.GetEnvironmentVariable("OIDC_CLIENT_URI")}/authentication/login-callback",
                                            "https://localhost:44343/authentication/login-callback",
                                            "https://localhost:5001/authentication/login-callback"
                                        },
                        PostLogoutRedirectUris = {
                                            $"{Environment.GetEnvironmentVariable("OIDC_CLIENT_URI")}/authentication/logout-callback",
                                            "https://localhost:44343/authentication/logout-callback",
                                            "https://localhost:5001/authentication/logout-callback"
                                        },
                        AllowedCorsOrigins = {
                                            $"{Environment.GetEnvironmentVariable("OIDC_CLIENT_URI")}",
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
