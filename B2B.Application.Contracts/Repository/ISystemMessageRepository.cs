using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.SystemMessages;
using B2B.Framework.Contracts.Common.Enums;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository
{
    public interface ISystemMessageRepository : IRepository
    {
        Task<SystemMessage> GetMessageByCodeAndType(int code, TypeSystemMessage type);
        Task<SystemDataMessage> GetDataMessageByCodeAndType(int code, TypeSystemMessage type, ContentLanguage language);
        Task<SystemMessage> GetMessageByCode(int code);
        Task<bool> Create(SystemMessage systemMessage);
        Task<bool> Update(SystemMessage systemMessage);
        Task<bool> Delete(int code);
        Task<List<SystemMessage>> GetAll();
    }
}
