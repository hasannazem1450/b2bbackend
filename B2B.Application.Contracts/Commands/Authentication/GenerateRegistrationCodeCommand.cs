using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands.Authentication;

public class GenerateRegistrationCodeCommand : Command
{
    public string Mobile { get; set; }
}

public class GenerateRegistrationCodeCommandResponse : CommandResponse
{
}