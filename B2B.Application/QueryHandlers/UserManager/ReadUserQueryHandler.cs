﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.UserManager;
using B2B.Application.Contracts.Queries.SystemMessages;
using B2B.Application.Contracts.Queries.UserManager;
using B2B.Application.Contracts.Repository;
using B2B.Framework.Contracts.Markers;
using B2B.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace B2B.Application.QueryHandlers.UserManager
{
    public class ReadUserQueryHandler : IQueryHandler<ReadUserQuery, ReadUserQueryResponse>
    {
        private readonly UserManager<B2B.Domain.Identity.ApplicationUser> _userManager;
        public ReadUserQueryHandler(UserManager<B2B.Domain.Identity.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ReadUserQueryResponse> Execute(ReadUserQuery query, CancellationToken cancellationToken)
        {
            if (query.ObjectIsAnyNullOrEmpty())
            {
                var list = await _userManager.Users.ToListAsync(cancellationToken: cancellationToken);
                var result = new ReadUserQueryResponse();
                var dto = new List<AspUserNetDto>();

                foreach (var item in list)
                {
                    result.List.Add(new AspUserNetDto
                    {
                        UserName = item.UserName,
                        Email = item.Email,
                        NormalizedEmail = item.NormalizedEmail,
                        EmailConfirmed = item.EmailConfirmed,
                        ConcurrencyStamp = item.ConcurrencyStamp,
                        AccessFailedCount = item.AccessFailedCount,
                        LockoutEnabled = item.LockoutEnabled,
                        LockoutEnd = item.ConcurrencyStamp,
                        NormalizedUserName = item.NormalizedUserName,
                        PasswordHash = item.PasswordHash,
                        PhoneNumber = item.PhoneNumber,
                        PhoneNumberConfirmed = item.PhoneNumberConfirmed,
                        SecurityStamp = item.SecurityStamp,
                        TwoFactorEnabled = item.TwoFactorEnabled
                    });
                }
                return result;
            }

            var result2 = _userManager.Users;

            if (!query.Email.IsNullOrEmptyExtension())
                result2 = result2.Where(u => u.Email == query.Email);

            if (!query.NormalizedEmail.IsNullOrEmptyExtension())
                result2 = result2.Where(u => u.NormalizedEmail == query.NormalizedEmail);

            if (!query.UserName.IsNullOrEmptyExtension())
                result2 = result2.Where(u => u.UserName == query.UserName);

            if (!query.PhoneNumber.IsNullOrEmptyExtension())
                result2 = result2.Where(u => u.PhoneNumber == query.PhoneNumber);

            if (!query.NormalizedUserName.IsNullOrEmptyExtension())
                result2 = result2.Where(u => u.NormalizedUserName == query.NormalizedUserName);

            var list2 = await result2.ToListAsync(cancellationToken: cancellationToken);

            var response = new ReadUserQueryResponse();

            var dto2 = new List<AspUserNetDto>();

            foreach (var item in list2)
            {
                response.List.Add(new AspUserNetDto
                {
                    UserName = item.UserName,
                    Email = item.Email,
                    NormalizedEmail = item.NormalizedEmail,
                    EmailConfirmed = item.EmailConfirmed,
                    ConcurrencyStamp = item.ConcurrencyStamp,
                    AccessFailedCount = item.AccessFailedCount,
                    LockoutEnabled = item.LockoutEnabled,
                    LockoutEnd = item.ConcurrencyStamp,
                    NormalizedUserName = item.NormalizedUserName,
                    PasswordHash = item.PasswordHash,
                    PhoneNumber = item.PhoneNumber,
                    PhoneNumberConfirmed = item.PhoneNumberConfirmed,
                    SecurityStamp = item.SecurityStamp,
                    TwoFactorEnabled = item.TwoFactorEnabled
                });
            }
            return response;


        }
    }
}
