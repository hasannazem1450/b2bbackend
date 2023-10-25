﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.City;
using B2B.Application.Contracts.Queries.BaseInfo.City;
using B2B.Application.Contracts.Queries.RoleManager;
using B2B.Application.Contracts.Repository.BaseInfo;
using B2B.Application.Contracts.Services;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.QueryHandlers.BaseInfo.City
{
    public class ReadCityQueryHandler : IQueryHandler<ReadCityQuery, ReadCityQueryResponse>
    {
        private readonly ICityService _cityService;

        public ReadCityQueryHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<ReadCityQueryResponse> Execute(ReadCityQuery query, CancellationToken cancellationToken)
        {
            var cityDto = await _cityService.ReadCityByProvinceId(query.ProvinceId);

            var result = new ReadCityQueryResponse()
            {
                List = cityDto,
            };

            return result;
        }
    }
}
