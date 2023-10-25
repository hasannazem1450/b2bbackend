using B2B.Application.Contracts.Commands.BaseInfo.City;
using B2B.Application.Contracts.Repository.BaseInfo;
using B2B.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.CommandHandlers.BaseInfo.City
{
    public class CreateCityCommandHandler : CommandHandler<CreateCityCommand, CreateCityCommandResponse>
    {
        private readonly ICityRepository _cityRepository;


        public CreateCityCommandHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public override async Task<CreateCityCommandResponse> Executor(CreateCityCommand command)
        {
            var city = new Domain.BaseInfo.City(command.Name, command.Code, command.ProvinceId)
            {
                ProvinceId = command.ProvinceId
            };

            await _cityRepository.Create(city);

            return new CreateCityCommandResponse();
        }
    }
}
