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
    public class DeleteCityCommandHandler : CommandHandler<DeleteCityCommand, DeleteCityCommandResponse>
    {
        private readonly ICityRepository _cityRepository;


        public DeleteCityCommandHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public override async Task<DeleteCityCommandResponse> Executor(DeleteCityCommand command)
        {
            await _cityRepository.Delete(command.Id);

            return new DeleteCityCommandResponse();
        }
    }
}
