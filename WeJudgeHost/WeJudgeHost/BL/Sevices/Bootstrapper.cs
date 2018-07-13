using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace WeJudgeHost.BL.Sevices
{
    public static class Bootstrapper
    {
        internal static void Register(IServiceCollection services)
        {
            services.AddMvc();
        }
    }
}
