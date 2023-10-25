﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Queries.RoleManager;
using B2B.Application.Contracts.Queries.SystemMessages;
using B2B.Framework.Contracts.Markers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace B2B.Application.QueryHandlers.RoleManager
{
    public class
        ReadRoleQueryHandler : IQueryHandler<ReadRoleQuery, ReadRoleQueryResponse>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public ReadRoleQueryHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ReadRoleQueryResponse> Execute(ReadRoleQuery query,
            CancellationToken cancellationToken)
        {
            var role = await _roleManager.Roles.ToListAsync(cancellationToken: cancellationToken);

            var result = new ReadRoleQueryResponse();

            foreach (var item in role)
            {
                var dto = new RoleDto()
                {
                    Id = Guid.Parse(item.Id),
                    Name = item.Name,
                    NormalizedName = item.Name,
                    ConcurrencyStamp = Guid.Parse(item.ConcurrencyStamp),
                };

                result.List.Add(dto);
            }

            return result;
        }
    }
}
