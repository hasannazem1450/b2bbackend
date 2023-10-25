using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands.Authentication;

public class ActivatingRegistrationCommand : Command
{
    public string Mobile { get; set; }
    public string ActivationCode { get; set; }
}

public class ActivatingRegistrationCommandResponse : CommandResponse
{
}