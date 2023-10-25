using B2B.Application.Contracts.ACLs.Sms.Models;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.ACLs.Sms;

public interface ISmsAcl : IAcl
{
    Task<SmsAclOutputModel> Send(SmsAclInputModel model);
}