using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.Project.Exceptions;
using B2B.Domain.SystemMessages;
using B2B.Domain.SystemMessages.Exceptions;
using B2B.Framework.Contracts.Common.Enums;
using FluentAssertions;
using Xunit;

namespace B2B.UnitTests.SystemMessages
{
    public class SystemMessageTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Throw_Exception_When_Id_Is_Invalid(int value)
        {
            Action action = () => new SystemMessage(value , TypeSystemMessage.Error , new List<SystemDataMessage>());

            action.Should().Throw<SystemErrorCodeIsInvalidException>();
        }
        
        [Fact]
        public void Should_Throw_Exception_When_SystemDataMessage_Is_Null()
        {
            Action action = () => new SystemMessage(1, TypeSystemMessage.Error, new List<SystemDataMessage>());

            action.Should().Throw<SystemErrorMessageIsEmptyException>();
        }

        [Fact]
        public void Should_Not_Throw_Exception_When_Values_Are_Valid()
        {
            var message = new List<SystemDataMessage>()
            {
                new SystemDataMessage(ContentLanguage.English, "test", "test"),
                new SystemDataMessage(ContentLanguage.Persian, "test", "test"),
            };

            Action action = () => new SystemMessage(1, TypeSystemMessage.Error, message);

            action.Should().NotThrow();
        }
    }
}
