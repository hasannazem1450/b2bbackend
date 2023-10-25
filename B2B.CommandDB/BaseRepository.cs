using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.CommandDB;

namespace B2B.CommandDb
{
    public abstract class BaseRepository
    {
        protected readonly BaseProjectCommandDb _Db;

        protected BaseRepository(BaseProjectCommandDb db)
        {
            _Db = db;
        }
    }
}
