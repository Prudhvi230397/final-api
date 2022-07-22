// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IS4SERVER
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[] {
            new ApiResource("AirLineMicroservices","AirLineMicroservices"),
            new ApiResource("BookingWebServices","BookingWebServices"),
            new ApiResource("SearchWebServices","SearchWebServices"),
            new ApiResource("TicketWebServices","TicketWebServices"),
          
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new Client[] 
            {
            new Client
                {
                    ClientId="clientAdmin",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secretAdmin".Sha256())
                    },
                    AllowedScopes={"AirLineMicroservices","BookingWebServices","SearchWebServices","TicketWebServices"},
                    AccessTokenLifetime = 6000,
                    IdentityTokenLifetime=6000
                },
                new Client
                {
                    ClientId="clientUser",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secretUser".Sha256())
                    },
                    AllowedScopes={"BookingWebServices","SearchWebServices","TicketWebServices"},
                    AccessTokenLifetime = 6000,
                    IdentityTokenLifetime=6000
                },
            };
        }
    }
}