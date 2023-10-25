using B2B.Domain.Profile;
using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Common.Enums;

namespace B2B.Domain.Event;

public class EventAttender : Entity<int>
{
    public EventAttender(int smeProfileId, int eventInfoId, EventAttenderType eventAttenderType, string contactNumber)
    {
        SmeProfileId = smeProfileId;
        EventInfoId = eventInfoId;
        EventAttenderType = eventAttenderType;
        ContactNumber = contactNumber;
    }

    public int SmeProfileId { get; protected set; }
    public SmeProfile SmeProfile { get; protected set; }

    public int EventInfoId { get; protected set; }
    public EventInfo EventInfo { get; protected set; }

    public EventAttenderType EventAttenderType { get; protected set; }

    public string ContactNumber { get; protected set; }

}