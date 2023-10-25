﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Domain.MessageCodes
{
    public class ExceptionCodes
    {
        public class Project
        {
            public static DomainExceptionMessageCode NameIsNullOrEmpty = 1;
            public static DomainExceptionMessageCode PriceIsNullOrEmpty = 2;
        }

        public class Identity
        {
            public static DomainExceptionMessageCode IdentityError = 10;
            public static DomainExceptionMessageCode UsernameOrPasswordIncorrect = 11;
            public static DomainExceptionMessageCode ClientHaveNoToken = 12;
        }

        public class SystemMessage
        {
            public static DomainExceptionMessageCode SystemErrorCodeIsInvalid = 20;
            public static DomainExceptionMessageCode SystemErrorMessageIsEmpty = 21;
        }

        public class Roll
        {
            public static DomainExceptionMessageCode CreateRollError = 30;
            public static DomainExceptionMessageCode DeleteRollError = 31;
        }
    }
}

