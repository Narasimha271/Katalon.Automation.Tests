using Katalon.Automation.Tests.Drivers;
using Katalon.Automation.Tests.Pages;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalon.Automation.Tests
{
    public class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateService()
        {
            var services = new ServiceCollection();
            services.AddScoped<DriverHelper>()
                .AddScoped<DriverSetup>()  
                .AddScoped<Page_Cart>()
                .AddScoped<Page_KatalonShop>()
                .AddScoped<Page_Home>();

            return services;
        }
    }
}
