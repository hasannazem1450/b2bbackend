using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands.Profile.SmeProfile;

public class DeleteSmeProfileCommand : Command
{
    public int Id { get; set; }
}

public class DeleteSmeProfileCommandResponse : CommandResponse
{

}