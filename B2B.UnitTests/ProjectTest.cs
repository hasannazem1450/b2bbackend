using B2B.Domain.Project;
using B2B.Domain.Project.Exceptions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace B2B.UnitTests
{
    public class ProjectTest
    {
        [Fact]
        public void Should_Throw_Exception_When_Name_Is_Null()
        {
            Action action = () => new Project(String.Empty, 1);
            action.Should().Throw<ProjectNameIsNullOrEmptyException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_Throw_Exception_When_Number_Is_Invalid(int value)
        {
            Action action = () => new Project("test", 0);
            action.Should().Throw<ProjectPriceIsNullOrEmptyException>();
        }
    }
}
