using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Event;
using B2B.Application.Contracts.Commands.News;
using B2B.Application.Contracts.Repository.News;
using B2B.Application.Contracts.Repository.Profile.Member;
using B2B.Domain.Profile.Member;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.News
{
    public class DeleteNewsCommandHandler : CommandHandler<DeleteNewsCommand, DeleteNewsCommandResponse>
    {

        private readonly INewsRepository _newsRepository;


        public DeleteNewsCommandHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public override async Task<DeleteNewsCommandResponse> Executor(DeleteNewsCommand command)
        {
            await _newsRepository.Delete(command.Id);

            return new DeleteNewsCommandResponse();
        }
    }
}
