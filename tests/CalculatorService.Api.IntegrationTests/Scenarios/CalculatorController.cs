using CalculatorService.Api.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net;

namespace CalculatorService.Api.IntegrationTests.Scenarios
{
    public class CalculatorController : BaseIntegrationTest
    {
        public CalculatorController(HostFixture host) : base(host)
        {
        }

        [Fact]
        public async Task Post_calculadoradd_and_response_ok_status_code()
        {
            var operation = new AddOperation.RequestDto() { Addens = new List<int> { 3, 2, 1 } };

            var content = new StringContent(JsonSerializer.Serialize(operation), UTF8Encoding.UTF8, "application/json");

            var response = await _host.Server.CreateClient().PostAsync("/calculator/add", content);
            
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<AddOperation.ResponseDto>(await response.Content.ReadAsStringAsync());

            result.Should().NotBeNull();
            result.Sum.Should().Be(6);
        }

        [Fact]
        public async Task Post_calculadoradd_and_response_bad_request_status_code()
        {
            var operation = new AddOperation.RequestDto() { };

            var content = new StringContent(JsonSerializer.Serialize(operation), UTF8Encoding.UTF8, "application/json");

            var response = await _host.Server.CreateClient().PostAsync("/calculator/add", content);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        [Fact]
        public async Task Post_calculadorsub_and_response_ok_status_code()
        {
            var operation = new SubOperation.RequestDto() { Subtrahend =5, Minuend = 3 };

            var content = new StringContent(JsonSerializer.Serialize(operation), UTF8Encoding.UTF8, "application/json");

            var response = await _host.Server.CreateClient().PostAsync("/calculator/sub", content);

            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<SubOperation.ResponseDto> (await response.Content.ReadAsStringAsync());

            result.Difference.Should().Be(-2);
        }

        [Fact]
        public async Task Post_calculadormult_and_response_ok_status_code()
        {
            var operation = new MultOperation.RequestDto() { Factors = new List<int> { 3, 2, 2 } };

            var content = new StringContent(JsonSerializer.Serialize(operation), UTF8Encoding.UTF8, "application/json");

            var response = await _host.Server.CreateClient().PostAsync("/calculator/mult", content);

            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<MultOperation.ResponseDto>(await response.Content.ReadAsStringAsync());

            result.Should().NotBeNull();
            result.Product.Should().Be(12);
        }

        [Fact]
        public async Task Post_calculadormult_and_response_bad_request_status_code()
        {
            var operation = new MultOperation.RequestDto() { };

            var content = new StringContent(JsonSerializer.Serialize(operation), UTF8Encoding.UTF8, "application/json");

            var response = await _host.Server.CreateClient().PostAsync("/calculator/mult", content);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        [Fact]
        public async Task Post_calculadordiv_and_response_ok_status_code()
        {
            var operation = new DivOperation.RequestDto() { Dividend = 5, Divisor = 2 };

            var content = new StringContent(JsonSerializer.Serialize(operation), UTF8Encoding.UTF8, "application/json");

            var response = await _host.Server.CreateClient().PostAsync("/calculator/div", content);

            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<DivOperation.ResponseDto>(await response.Content.ReadAsStringAsync());

            result.Should().NotBeNull();
            result.Quotient.Should().Be(2);
            result.Remainder.Should().Be(1);
        }

        [Fact]
        public async Task Post_calculadordiv_and_response_bad_request_status_code()
        {
            var operation = new DivOperation.RequestDto() { };

            var content = new StringContent(JsonSerializer.Serialize(operation), UTF8Encoding.UTF8, "application/json");

            var response = await _host.Server.CreateClient().PostAsync("/calculator/div", content);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        [Fact]
        public async Task Post_calculadorsqrt_and_response_ok_status_code()
        {
            var operation = new SqrtOperation.RequestDto() { Number= 16 };

            var content = new StringContent(JsonSerializer.Serialize(operation), UTF8Encoding.UTF8, "application/json");

            var response = await _host.Server.CreateClient().PostAsync("/calculator/sqrt", content);

            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<SqrtOperation.ResponseDto>(await response.Content.ReadAsStringAsync());

            result.Should().NotBeNull();
            result.Square.Should().Be(4);
        }
    }
}
