using B2B.Application.CommandHandlers.Authentication.Exceptions;
using B2B.Application.Contracts.Commands.Authentication;
using B2B.Application.Contracts.Repository.Sms;
using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Common.Enums;
using B2B.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;

namespace B2B.Application.CommandHandlers.Authentication;

public class ActivatingRegistrationCommandHandler : CommandHandler<ActivatingRegistrationCommand,
    ActivatingRegistrationCommandResponse>
{

    private readonly ISmsInfoRepository _smsInfoRepository;
    private readonly UserManager<B2B.Domain.Identity.ApplicationUser> _userManager;

    public ActivatingRegistrationCommandHandler(ISmsInfoRepository smsInfoRepository, UserManager<B2B.Domain.Identity.ApplicationUser> userManager)
    {
        _smsInfoRepository = smsInfoRepository;
        _userManager = userManager;
    }

    public override async Task<ActivatingRegistrationCommandResponse> Executor(ActivatingRegistrationCommand command)
    {
        var smsInfo = await _smsInfoRepository.ReadLastByReceiverNumber(command.Mobile.ConvertToValidMobile(), SmsType.ActivatingRegistration);

        if (smsInfo != null && smsInfo.Code != command.ActivationCode)
            throw new ActivatingCodeIsInvalidException();

        var userUpdate = _userManager.Users.OrderByDescending(x => x.Id).FirstOrDefault(x => x.PhoneNumber == command.Mobile);
        if (userUpdate != null)
        {
            userUpdate.PhoneNumberConfirmed = true;
            await _userManager.UpdateAsync(userUpdate);
        }

        return new ActivatingRegistrationCommandResponse();
    }
}