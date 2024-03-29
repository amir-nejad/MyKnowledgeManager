﻿using IdentityServer4.Models;

namespace MyKnowledgeManager.IdentityServer.IdentityConfiguration
{
    public static class IdentityResourcesConfiguration
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
           new IdentityResource[]
           {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
           };
    }
}
