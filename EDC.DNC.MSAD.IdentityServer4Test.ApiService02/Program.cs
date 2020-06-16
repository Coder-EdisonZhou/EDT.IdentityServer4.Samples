﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace EDC.DNC.MSAD.IdentityServer4Test.ApiService02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
