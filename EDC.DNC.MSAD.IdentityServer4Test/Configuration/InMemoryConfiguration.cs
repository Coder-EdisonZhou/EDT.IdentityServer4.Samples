﻿using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EDC.DNC.MSAD.IdentityServer4Test.Configuration
{
    public class InMemoryConfiguration
    {
        public static IConfiguration Configuration { get; set; }
        /// <summary>
        /// Define which APIs will use this IdentityServer
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource("clientservice", "CAS Client Service"),
                new ApiResource("productservice", "CAS Product Service"),
                new ApiResource("agentservice", "CAS Agent Service")
            };
        }

        /// <summary>
        /// Define which Apps will use thie IdentityServer
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "client.api.service",
                    ClientSecrets = new [] { new Secret("clientsecret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new [] { "clientservice" }
                },
                new Client
                {
                    ClientId = "product.api.service",
                    ClientSecrets = new [] { new Secret("productsecret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new [] { "clientservice", "productservice" }
                },
                new Client
                {
                    ClientId = "agent.api.service",
                    ClientSecrets = new [] { new Secret("agentsecret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new [] { "agentservice", "clientservice", "productservice" }
                },
                new Client
                {
                    ClientId = "cas.mvc.client.implicit",
                    ClientName = "CAS MVC Web App Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { $"http://{Configuration["Clients:MvcClient:IP"]}:{Configuration["Clients:MvcClient:Port"]}/signin-oidc" },
                    PostLogoutRedirectUris = { $"http://{Configuration["Clients:MvcClient:IP"]}:{Configuration["Clients:MvcClient:Port"]}/signout-callback-oidc" },
                    AllowedScopes = new [] {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "agentservice", "clientservice", "productservice"
                    },
                    //AccessTokenLifetime = 3600, // one hour
                    AllowAccessTokensViaBrowser = true // can return access_token to this client
                }
            };
        }

        /// <summary>
        /// Define which uses will use this IdentityServer
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TestUser> GetUsers()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "10001",
                    Username = "edison@hotmail.com",
                    Password = "edisonpassword"
                },
                new TestUser
                {
                    SubjectId = "10002",
                    Username = "andy@hotmail.com",
                    Password = "andypassword"
                },
                new TestUser
                {
                    SubjectId = "10003",
                    Username = "leo@hotmail.com",
                    Password = "leopassword"
                }
            };
        }

        /// <summary>
        /// Define which IdentityResources will use this IdentityServer
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
    }
}
