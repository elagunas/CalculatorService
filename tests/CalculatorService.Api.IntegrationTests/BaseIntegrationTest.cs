using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculatorService.Api.IntegrationTests
{
    public class BaseIntegrationTest : IClassFixture<HostFixture>
    {
        protected HostFixture _host;

        public BaseIntegrationTest(HostFixture host)
        {
            _host = host;
        }


    }
}
