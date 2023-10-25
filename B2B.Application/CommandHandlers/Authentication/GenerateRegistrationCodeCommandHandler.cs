using B2B.Application.CommandHandlers.Authentication.Exceptions;
using B2B.Application.Contracts.ACLs.Sms;
using B2B.Application.Contracts.ACLs.Sms.Models;
using B2B.Application.Contracts.Commands.Authentication;
using B2B.Application.Contracts.Repository.Sms;
using B2B.Domain.Sms;
using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Common.Enums;
using B2B.Settings;
using B2B.Utilities.Extensions;
using Microsoft.Extensions.Options;

namespace B2B.Application.CommandHandlers.Authentication;

public class
    GenerateRegistrationCodeCommandHandler : CommandHandler<GenerateRegistrationCodeCommand,
        GenerateRegistrationCodeCommandResponse>
{
    private readonly ISmsAcl _smsAcl;
    private readonly ISmsInfoRepository _smsInfoRepository;
    private readonly SmsSetting _smsSetting;

    public GenerateRegistrationCodeCommandHandler(ISmsAcl smsAcl, ISmsInfoRepository smsInfoRepository,
        IOptions<SmsSetting> smsOptions)
    {
        _smsAcl = smsAcl;
        _smsInfoRepository = smsInfoRepository;
        _smsSetting = smsOptions.Value;
    }

    public override async Task<GenerateRegistrationCodeCommandResponse> Executor(
        GenerateRegistrationCodeCommand command)
    {
        var activationCode = new Random().Next(10000, 99999).ToString();
        var message = _smsSetting.ActivatingRegistrationMessage.Replace("{activationCode}", activationCode);
        var receiverMobile = command.Mobile.RemoveMobilePrefix();

        var smsAclOutputModel = await _smsAcl.Send(new SmsAclInputModel { Message = message, Receiver = receiverMobile });

        if (!smsAclOutputModel.IsSuccess)
            throw new ActivatingCodeNotSendedException();

        var smsInfo = new SmsInfo(_smsSetting.Sender, receiverMobile.ConvertToValidMobile(), message, activationCode,
            SmsType.ActivatingRegistration);

        await _smsInfoRepository.Create(smsInfo);

        return new GenerateRegistrationCodeCommandResponse();
    }
}