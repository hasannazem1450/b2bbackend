using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.ACLs.Sms.Models;

public class SmsAclOutputModel : IAclOutputModel
{
    public bool IsSuccess { get; set; }
}