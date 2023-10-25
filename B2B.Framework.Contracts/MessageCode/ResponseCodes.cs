using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Framework.Contracts.MessageCode
{
    public static class ResponseCodes
    {
        public static FrameworkResponseMessageCode OPERATION_SUCCESSFULL = new CodeAndMessage { Code = 1, Message = "The operation was successful." };
        public static FrameworkResponseMessageCode OPERATION_FAILED = new CodeAndMessage { Code = 2, Message = "The operation was failed." };
        public static FrameworkResponseMessageCode OPERATION_CANCELED = new CodeAndMessage { Code = 3, Message = "The operation was canceled." };
    }
}
