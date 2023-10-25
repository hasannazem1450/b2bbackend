using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.MessageCodes;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Domain.Project.Exceptions
{
    public sealed class ProjectNameIsNullOrEmptyException : BusinessException
    {
        public ProjectNameIsNullOrEmptyException()
            : base(ExceptionCodes.Project.NameIsNullOrEmpty)
        {
        }

        public override string PersianMessage => "نام خالی میباشد";
        public override string EnglishMessage => "The Name Is Null Or Empty";

    }
}
