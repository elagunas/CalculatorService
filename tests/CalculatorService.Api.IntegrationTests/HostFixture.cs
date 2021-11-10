using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CalculatorService.Api.IntegrationTests
{
    public class HostFixture
    {
        public TestServer Server { get; }

        public HostFixture()
        {
            var path = Assembly.GetAssembly(typeof(BaseIntegrationTest))
               .Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
            .UseStartup<TestStartup>();

            Server = new TestServer(hostBuilder);

        }
    }
}
