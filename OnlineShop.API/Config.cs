using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShop.API
{
    public class Config
    {
        //public static IEnumerable<IdentityResource> GetIdentityResources()
        //{
        //    return new List<IdentityResource>
        //    {
        //        new IdentityResources.OpenId(),
        //        new IdentityResources.Profile(),
        //        new IdentityResources.Email(),
        //        new IdentityResource
        //        {
        //            Name = "Admin",
        //            DisplayName = "Administrator",
        //            Description = "Have acces to all data",
        //            ShowInDiscoveryDocument = true
        //        }
        //    };

        //}

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("resourceApi", "API Application")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    //ClientName = "SPA Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowAccessTokensViaBrowser = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    //RedirectUris = { "http://localhost:4200/callback" },
                    //PostLogoutRedirectUris = { "http://localhost:4200" },

                    //ClientSecrets =
                    //{
                    //    new Secret("secret".Sha256())
                    //},
                    AllowedScopes =
                    {
                        "resourceApi"
                    }
                    //Claims =
                    //{
                    //    new Claim(JwtClaimTypes.Role, "Customer"),
                    //    new Claim(JwtClaimTypes.Role, "Admin")
                    //}
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        //public static List<TestUser> GetUsers()
        //{
        //    return new List<TestUser> {
        //        new TestUser
        //        {
        //            SubjectId = "1",
        //            Username = "systemuser",
        //            Password = "123",
        //            Claims = {
        //            new Claim(JwtClaimTypes.Name,"Systemuser"),
        //            new Claim(JwtClaimTypes.Role,"system"),
        //            new Claim(JwtClaimTypes.Email, "systemuser@mycompany.com")
        //            }
        //        },
        //        new TestUser
        //        {
        //            SubjectId = "2",
        //            Username = "adminuser",
        //            Password = "123",
        //            Claims = {
        //                new Claim(JwtClaimTypes.Name,"Adminuser"),
        //                new Claim(JwtClaimTypes.Role,"admin"),
        //                new Claim(JwtClaimTypes.Email, "adminuser@mycompany.com")                    }
        //        },
        //        new TestUser
        //        {
        //            SubjectId = "3",
        //            Username = "testuser",
        //            Password = "123",
        //            Claims = {
        //                new Claim(JwtClaimTypes.Name,"Testuser"),
        //                new Claim(JwtClaimTypes.Role,"test"),
        //                new Claim(JwtClaimTypes.Email, "testuser@mycompany.com")
        //            }
        //        }
        //    };
        //}
    }
}
