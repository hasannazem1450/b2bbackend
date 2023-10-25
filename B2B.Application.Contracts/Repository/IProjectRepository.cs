using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.Project;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository
{
    public interface IProjectRepository :IRepository
    {
        Task<bool> Create(Project project);
    }
}
