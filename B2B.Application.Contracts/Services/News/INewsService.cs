
using B2B.Application.Contracts.Commands.News;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Services.News
{
    public interface INewsService : IService
    {
        Task<NewsDto> ReadById(int id);
        //Task<List<NewsDto>> Read();
        Task<List<NewsDto>> ReadNewsBySmeProfileId(int SmeProfileId);
    }
}
