﻿using B2B.Application.Contracts.Commands.Profile.SmeProfile;
using B2B.Application.Contracts.Services.Profile;
using B2B.Domain.Profile;
using B2B.Utilities.Extensions;

namespace B2B.Application.Services.Profile;

public class SmeProfileService : ISmeProfileService
{
    public async Task<List<SmeProfileDto>> ConvertToDto(List<SmeProfile> smeProfiles)
    {
        var result = smeProfiles.Select(s => ConvertToDto(s).Result).ToList();

        return result;
    }

    public async Task<SmeProfileDto> ConvertToDto(SmeProfile smeProfile)
    {
        var result = new SmeProfileDto
        {
            Id = smeProfile.Id,
            AboutUs = smeProfile.AboutUs,
            Address = smeProfile.Address,
            BusinessCode = smeProfile.BusinessCode,
            CityId = smeProfile.CityId,
            CityName = smeProfile.City?.Name ?? "",
            ProvinceId = smeProfile.City?.ProvinceId ?? 0,
            ProvinceName = smeProfile.City?.Province?.Name ?? "",
            EconomyCode = smeProfile.EconomyCode,
            ActivitySubject = smeProfile.ActivitySubject,
            IndustrialParkName = smeProfile.IndustrialPark?.Name ?? "",
            ManagerEmail = smeProfile.ManagerEmail,
            ManagerName = smeProfile.ManagerName,
            ManagerPhoneNumber = smeProfile.ManagerPhoneNumber,
            NationalCode = smeProfile.NationalCode,
            PermitNo = smeProfile.PermitNo,
            RegisterNumber = smeProfile.RegisterNumber,
            SmeEmail = smeProfile.SmeEmail,
            SmeName = smeProfile.SmeName,
            SmeWebsite = smeProfile.SmeWebsite,
            Status = smeProfile.Status,
            TellNumber = smeProfile.TellNumber,
            Postalcode = smeProfile.Postalcode,
            Logo = smeProfile.Logo,
            Headerpic = smeProfile.Headerpic,
            SmeType = (int)smeProfile.SmeType,
            SmeTypeName = smeProfile.SmeType.GetDescription()
        };

        return result;
    }

    public async Task<List<PreSmeProfileDto>> ConvertToPreDto(List<SmeProfile> smeProfiles)
    {
        var result = smeProfiles.Select(s => ConvertToPreDto(s).Result).ToList();

        return result;
    }

    public async Task<PreSmeProfileDto> ConvertToPreDto(SmeProfile smeProfile)
    {
        var result = new PreSmeProfileDto
        {
            Id = smeProfile.Id,
            Address = smeProfile.Address,
            CityName = smeProfile.City?.Name ?? "",
            ManagerName = smeProfile.ManagerName,
            SmeName = smeProfile.SmeName
        };

        return result;
    }
}