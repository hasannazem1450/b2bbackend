using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.MessageCodes;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Domain.Project.Exceptions
{
    public sealed class ProjectPriceIsNullOrEmptyException : BusinessException
    {
        public override string Message => "";

        public ProjectPriceIsNullOrEmptyException()
            : base(ExceptionCodes.Project.PriceIsNullOrEmpty)
        {
        }

        public override string PersianMessage => "قیمت خالی میباشد";
        public override string EnglishMessage => "The Price Is Null Or Empty";
    }
}
