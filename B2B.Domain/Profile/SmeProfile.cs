﻿using B2B.Domain.BaseInfo;
using B2B.Domain.Event;
using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Common.Enums;

namespace B2B.Domain.Profile;

public class SmeProfile : Entity<int>
{
    public SmeProfile(string smeName, string nationalCode, string? businessCode, string? managerName,
        string? registerNumber, string? economyCode, string? permitNo, string managerPhoneNumber, string managerEmail,
        string aboutUs, string tellNumber, string activitySubject, string smeEmail, string smeWebsite, string address,
        int cityId, int? smeRankId, int? industrialParkId, bool status, string logo, string headerpic, string postalcode,
        SmeType smeType)
    {
        CheckGuard();

        SmeName = smeName;
        NationalCode = nationalCode;
        BusinessCode = businessCode;
        ManagerName = managerName;
        RegisterNumber = registerNumber;
        EconomyCode = economyCode;
        PermitNo = permitNo;
        ManagerPhoneNumber = managerPhoneNumber;
        ManagerEmail = managerEmail;
        AboutUs = aboutUs;
        TellNumber = tellNumber;
        ActivitySubject = activitySubject;
        SmeEmail = smeEmail;
        SmeWebsite = smeWebsite;
        Address = address;
        CityId = cityId;
        IndustrialParkId = industrialParkId;
        Status = status;
        Logo = logo;
        Headerpic = headerpic;
        Postalcode = postalcode;
        SmeType = smeType;
        SmeRankId = (int)smeRankId;
    }

    public string SmeName { get; protected set; }
    public string NationalCode { get; protected set; }
    public string? BusinessCode { get; protected set; }
    public string ManagerName { get; protected set; }
    public string? RegisterNumber { get; protected set; }
    public string? EconomyCode { get; protected set; }
    public string? PermitNo { get; protected set; }
    public string ManagerPhoneNumber { get; protected set; }
    public string ManagerEmail { get; protected set; }
    public string AboutUs { get; protected set; }
    public string TellNumber { get; protected set; }
    public string ActivitySubject { get; protected set; }
    public string SmeEmail { get; protected set; }
    public string SmeWebsite { get; protected set; }
    public string? Address { get; protected set; }
    public bool Status { get; protected set; }
    public string Logo { get; protected set; }
    public string Headerpic { get; protected set; }
    public string Postalcode { get; protected set; }
    public SmeType SmeType { get; protected set; }

    public int CityId { get; protected set; }
    public City City { get; protected set; }

    public int? SmeRankId { get; protected set; }
    public SmeRank SmeRank { get; protected set; }

    public int? IndustrialParkId { get; protected set; }
    public IndustrialPark IndustrialPark { get; protected set; }

    public ICollection<SmeMember> SmeMembers { get; protected set; }

    public ICollection<News.News> News { get; protected set; }
    public ICollection<EventAttender> AttendedEvents { get; protected set; }

    public void SetIsDeleted(bool isDeleted)
    {
        IsDeleted = isDeleted;
    }

    public void Update(string smeName, string nationalCode, string businessCode, string managerName,
        string registerNumber, string economyCode, string permitNo, string managerPhoneNumber, string managerEmail,
        string aboutUs, string tellNumber, string activitySubject, string smeEmail, string smeWebsite, string address,
        int cityId, int smeRankId, int industrialParkId, bool status, string logo,
        string headerpic, string postalcode, SmeType smeType)
    {
        SmeName = smeName;
        NationalCode = nationalCode;
        BusinessCode = businessCode;
        ManagerName = managerName;
        RegisterNumber = registerNumber;
        EconomyCode = economyCode;
        PermitNo = permitNo;
        ManagerPhoneNumber = managerPhoneNumber;
        ManagerEmail = managerEmail;
        AboutUs = aboutUs;
        TellNumber = tellNumber;
        ActivitySubject = activitySubject;
        SmeEmail = smeEmail;
        SmeWebsite = smeWebsite;
        Address = address;
        CityId = cityId;
        SmeRankId = smeRankId;
        IndustrialParkId = industrialParkId;
        Status = status;
        Logo = logo;
        Headerpic = headerpic;
        Postalcode = postalcode;
        SmeType = smeType;
    }

    private void CheckGuard()
    {
    }
}