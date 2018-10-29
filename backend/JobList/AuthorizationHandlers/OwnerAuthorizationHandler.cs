using JobList.Common.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobList.AuthorizationHandlers
{
    public class OwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, int>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       OperationAuthorizationRequirement requirement,
                                                       int id)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            if (context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value == id.ToString())
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

}
