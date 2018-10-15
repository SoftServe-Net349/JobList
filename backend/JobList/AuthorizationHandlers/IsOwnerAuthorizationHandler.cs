using JobList.Common.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobList.AuthorizationHandlers
{
    public class IsOwnerAuthorizationHandler : AuthorizationHandler<SameUserRequirement, UserDTO>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       SameUserRequirement requirement,
                                                       UserDTO userDTO)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            if (context.User.Identity.Name == userDTO.Id.ToString())
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    public class SameUserRequirement : IAuthorizationRequirement { }
}
