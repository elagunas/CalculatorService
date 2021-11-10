using CalculatorService.Api.Contracts.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculatorService.Client
{
    public class CalculatorServiceApiClient
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true).Build();

        public CalculatorServiceApiClient()
        {
            client.BaseAddress = new Uri(Configuration["CalculatorApiAddres"]);
        }


        public async Task<string> AddOperation(IEnumerable<int> addends, string trackingId)
        {
            var requestDto = new AddOperation.RequestDto() {Addens = addends };

            var request = GenerateRequest("/calculator/add", new StringContent(JsonSerializer.Serialize(requestDto), UTF8Encoding.UTF8, "application/json"),trackingId);

            var response = await client.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync(); 

            return result;
        }

        public async Task<string> SubOperation(int minuend, int subtrahend, string trackingId)
        {
            var requestDto = new SubOperation.RequestDto() { Minuend = minuend, Subtrahend = subtrahend };

            var request = GenerateRequest("/calculator/sub", new StringContent(JsonSerializer.Serialize(requestDto), UTF8Encoding.UTF8, "application/json"), trackingId);

            var response = await client.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> DivOperation(int diviend, int divisor, string trackingId)
        {
            var requestDto = new DivOperation.RequestDto() { Dividend = diviend, Divisor = divisor };

            var request = GenerateRequest("/calculator/div", new StringContent(JsonSerializer.Serialize(requestDto), UTF8Encoding.UTF8, "application/json"), trackingId);

            var response = await client.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> MultOperation(IEnumerable<int> factors, string trackingId)
        {
            var requestDto = new MultOperation.RequestDto() { Factors = factors };

            var request = GenerateRequest("/calculator/mult", new StringContent(JsonSerializer.Serialize(requestDto), UTF8Encoding.UTF8, "application/json"), trackingId);

            var response = await client.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }


        public async Task<string> SqrtOperation(int number, string trackingId)
        {
            var requestDto = new SqrtOperation.RequestDto() { Number = number };

            var request = GenerateRequest("/calculator/sqrt", new StringContent(JsonSerializer.Serialize(requestDto), UTF8Encoding.UTF8, "application/json"), trackingId);

            var response = await client.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> JournalQueryOperation(string id)
        {
            var requestDto = new QueryJournalOperation.RequestDto() { Id =  id};

            var request = GenerateRequest("/journal/query", new StringContent(JsonSerializer.Serialize(requestDto), UTF8Encoding.UTF8, "application/json"), string.Empty);

            var response = await client.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        private HttpRequestMessage GenerateRequest(string requestUri, StringContent content, string trackingHeader)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);

            request.Content = content;

            if (!string.IsNullOrEmpty(trackingHeader))
            {
                request.Headers.Add("X-Evi-Tracking-Id", trackingHeader);
            }

           return request;
        }

    }
}
