using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Queries.SystemMessages;
using B2B.Application.Contracts.Repository;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.QueryHandlers.SystemMessages
{
    public class GetAllSystemErrorsQueryHandler : IQueryHandler<GetAllSystemErrorsQuery, GetAllSystemErrorsQueryResponse>
    {
        private readonly ISystemMessageRepository _systemErrorRepository;

        public GetAllSystemErrorsQueryHandler(ISystemMessageRepository systemErrorRepository)
        {
            _systemErrorRepository = systemErrorRepository;
        }

        public async Task<GetAllSystemErrorsQueryResponse> Execute(GetAllSystemErrorsQuery query, CancellationToken cancellationToken)
        {
            var list = await _systemErrorRepository.GetAll();

            var result = new GetAllSystemErrorsQueryResponse();

            foreach (var item in list)
            {
                var dto = new SystemErrorDto
                {
                    Code = item.Code
                };

                foreach (var mess in item.SystemDataMessages)
                {
                    dto.List.Add(new SystemErrorMessageDto
                    {
                        MessageLanguage = mess.MessageLanguage,
                        Prefix = mess.Prefix,
                        Message = mess.Message
                    });
                }
                result.List.Add(dto);
            }

            return result;
        }
    }
}
