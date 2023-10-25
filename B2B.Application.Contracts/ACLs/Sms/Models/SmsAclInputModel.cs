using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.ACLs.Sms.Models;

public class SmsAclInputModel : IAclInputModel
{
    public string Receiver { get; set; }
    public string Message { get; set; }
}