using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Repository;
using B2B.CommandDB;
using B2B.Domain.Project;

namespace B2B.CommandDb.Repository
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(BaseProjectCommandDb db) : base(db)
        {
        }
        public async Task<bool> Create(Project project)
        {
            await _Db.Projects.AddAsync(project);
            return await _Db.SaveChangesAsync() > 0;
        }
    }
}
