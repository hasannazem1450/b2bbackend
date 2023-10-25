﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.CommandHandlers.Authentication.Exceptions;
using B2B.Application.CommandHandlers.Exceptions;
using B2B.Application.Contracts.Commands.Authentication;
using B2B.Domain.Identity.Exceptions;
using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Common.Enums;
using B2B.Settings;
using B2B.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace B2B.Application.CommandHandlers.Authentication
{
    public class SignInCommandHandler : CommandHandler<SignInCommand, SignInCommandResponse>
    {
        private readonly SignInManager<B2B.Domain.Identity.ApplicationUser> _signInManager;
        private readonly UserManager<B2B.Domain.Identity.ApplicationUser> _userManager;
        private readonly JwtSetting JwtSetting;

        public SignInCommandHandler(SignInManager<B2B.Domain.Identity.ApplicationUser> signInManager, UserManager<B2B.Domain.Identity.ApplicationUser> userManager, IOptions<JwtSetting> options)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            JwtSetting = options.Value;
        }


        public override async Task<SignInCommandResponse> Executor(SignInCommand command)
        {
            if (command.UserName.IsNullOrEmptyExtension())
                throw new UserNameAndPasswordAreNullException();

            if (command.UserName.Length == 10)
            {
                if (!command.UserName.IsNationalCodeValid())
                    throw new IdentityException("شماره ملی معتبر نمیباشد .", "NationalCode is not valid .");

                var userExist = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == command.UserName.ToUpper());

                if (userExist.ObjectIsAnyNullOrEmpty())
                    throw new UserNotExistException();

                var user = new IdentityUser()
                {
                    UserName = command.UserName
                };

                var signOn = await _signInManager.PasswordSignInAsync(command.UserName, command.Password, command.IsPersistent, false);

                if (!signOn.Succeeded) throw new IdentityUsernameOrPasswordException();



                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("@#MY_BIG_SECRET_KEY@#");
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, userExist.Id)
                        }
                    ),
                    Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(JwtSetting.Time)),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature),
                };
                var token = tokenHandler.CreateToken(tokenDescription);
                var tokenString = tokenHandler.WriteToken(token);

                await _userManager.RemoveAuthenticationTokenAsync(userExist, userExist.Id, tokenString);
                var newRefreshToken = await _userManager.GenerateUserTokenAsync(userExist, "Default", tokenString);
                await _userManager.SetAuthenticationTokenAsync(userExist, userExist.UserName, "Authorization", tokenString);

                return new SignInCommandResponse()
                {
                    Token = $"Bearer {tokenString}",
                    ExpiredAt = JwtSetting.Time,
                    RefreshToken = $"Bearer {tokenString}",
                    UserFullname = userExist.Fullname ?? ""
                };
            }
            //TODO:FindByPhoneNumber
            else
            {
                if (command.UserName.Length != 13)
                {
                    command.UserName = command.UserName.Remove(0, 1);
                    command.UserName = $"+98{command.UserName}";
                }
                var userExist = await _userManager.Users.FirstOrDefaultAsync(l => l.PhoneNumber == command.UserName);

                if (userExist == null)
                    throw new UserNotExistException();

                var user = new IdentityUser()
                {
                    UserName = userExist.UserName
                };

                var signOn = await _signInManager.PasswordSignInAsync(userExist.UserName, command.Password, command.IsPersistent, false);

                if (!signOn.Succeeded) throw new IdentityUsernameOrPasswordException();


                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("@#MY_BIG_SECRET_KEY@#");
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, userExist.Id)
                        }
                    ),
                    Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(JwtSetting.Time)),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature),
                };
                var token = tokenHandler.CreateToken(tokenDescription);
                var tokenString = tokenHandler.WriteToken(token);


                await _userManager.RemoveAuthenticationTokenAsync(userExist, userExist.Id, tokenString);
                var newRefreshToken = await _userManager.GenerateUserTokenAsync(userExist, "Default", tokenString);
                await _userManager.SetAuthenticationTokenAsync(userExist, userExist.UserName, "Authorization", tokenString);

                return new SignInCommandResponse()
                {
                    Token = $"Bearer {tokenString}",
                    ExpiredAt = JwtSetting.Time,
                    RefreshToken = $"Bearer {tokenString}",
                };
            }
        }
    }
}
