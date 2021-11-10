using CalculatorService.Application.Journal.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using CalculatorService.Application.Calculator.Commands;

namespace CalculatorService.UnitTests.Application
{
    public class ValidatorsTest
    {
        [Fact]
        public void Should_have_error_when_addrequest_is_null()
        {
            var validator = new CalculatorAddValidator();

            var command = new CalculatorAddCommand(null);

            validator.Validate(command).IsValid.Should().BeFalse();
        }

        [Fact]
        public void Should_be_valid_when_addrequest_is_not_null()
        {
            var validator = new CalculatorAddValidator();

            var request = new Api.Contracts.DTOs.AddOperation.RequestDto()
            {
                Addens = new List<int> { 3,3}
            };

            var command = new CalculatorAddCommand(request);

            validator.Validate(command).IsValid.Should().BeTrue();
        }

        [Fact]
        public void Should_have_error_when_subrequest_is_null()
        {
            var validator = new CalculatorSubValidator();

            var command = new CalculatorSubCommand(null);

            validator.Validate(command).IsValid.Should().BeFalse();
        }

        [Fact]
        public void Should_be_valid_when_subrequest_is_not_null()
        {
            var validator = new CalculatorSubValidator();

            var request = new Api.Contracts.DTOs.SubOperation.RequestDto()
            {
               Subtrahend = 5, Minuend = 3
            };

            var command = new CalculatorSubCommand(request);

            validator.Validate(command).IsValid.Should().BeTrue();
        }

        [Fact]
        public void Should_have_error_when_divrequest_is_null()
        {
            var validator = new CalculatorDivValidator();

            var command = new CalculatorDivCommand(null);

            validator.Validate(command).IsValid.Should().BeFalse();
        }

        [Fact]
        public void Should_be_valid_when_divrequest_is_not_null()
        {
            var validator = new CalculatorDivValidator();

            var request = new Api.Contracts.DTOs.DivOperation.RequestDto()
            {
                Dividend =5 , Divisor =2
            };

            var command = new CalculatorDivCommand(request);

            validator.Validate(command).IsValid.Should().BeTrue();
        }

        [Fact]
        public void Should_have_error_when_multrequest_is_null()
        {
            var validator = new CalculatorMultValidator();

            var command = new CalculatorMultCommand(null);

            validator.Validate(command).IsValid.Should().BeFalse();
        }

        [Fact]
        public void Should_be_valid_when_multrequest_is_not_null()
        {
            var validator = new CalculatorMultValidator();

            var request = new Api.Contracts.DTOs.MultOperation.RequestDto()
            {
              Factors = new List<int>{ 3,5} 
            };

            var command = new CalculatorMultCommand(request);

            validator.Validate(command).IsValid.Should().BeTrue();
        }

        [Fact]
        public void Should_have_error_when_sqrtrequest_is_null()
        {
            var validator = new CalculatorSqrtValidator();

            var command = new CalculatorSqrtCommand(null);

            validator.Validate(command).IsValid.Should().BeFalse();
        }

        [Fact]
        public void Should_be_valid_when_sqrtrequest_is_not_null()
        {
            var validator = new CalculatorSqrtValidator();

            var request = new Api.Contracts.DTOs.SqrtOperation.RequestDto()
            {
                Number = 16
            };

            var command = new CalculatorSqrtCommand(request);

            validator.Validate(command).IsValid.Should().BeTrue();
        }


    }
}
