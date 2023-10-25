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
    public class CreateNewsCommandHandler : CommandHandler<CreateNewsCommand, CreateNewsCommandResponse>
    {

        private readonly INewsRepository _newsRepository;


        public CreateNewsCommandHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public override async Task<CreateNewsCommandResponse> Executor(CreateNewsCommand command)
        {
            var news = new Domain.News.News(command.Title, command.HeadLine, command.Description, command.Photo)
            {
                SmeProfileId = command.SmeProfileId
            };

            await _newsRepository.Create(news);

            return new CreateNewsCommandResponse();
        }
    }
}
