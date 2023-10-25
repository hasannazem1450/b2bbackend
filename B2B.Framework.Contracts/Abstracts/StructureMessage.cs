using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Common.Enums;

namespace B2B.Framework.Contracts.Abstracts
{
    public sealed class StructureMessage
    {
        public ContentLanguage MessageLanguage { get; set; }
        public string? Message { get; set; }
    }
}
