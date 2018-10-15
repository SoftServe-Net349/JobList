using JobList.Common.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobList.AuthorizationHandlers
{
    public class OwnerAuthorizationHandler : AuthorizationHandler<SameOwnerRequirement, int>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       SameOwnerRequirement requirement,
                                                       int id)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            if (context.User.Identity.Name == id.ToString())
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    public class SameOwnerRequirement : IAuthorizationRequirement { }
}
