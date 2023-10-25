using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.News;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository.News
{
    public interface INewsRepository : IRepository
    {
        Task<Domain.News.News> ReadById(int id);

        Task<List<Domain.News.News>> Read(NewsDto newsDto);

        Task Delete(int id);

        Task Update(Domain.News.News news);

        Task Create(Domain.News.News news);

        Task<List<Domain.News.News>> ReadNewsBySmeProfileId(int SmeProfileId);
    }
}
