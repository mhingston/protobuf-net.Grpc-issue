using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace DAL.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureKestrel(options =>
                {
                    options.ListenLocalhost(10042, listenOptions =>
                    {
                        var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                        var certPath = Path.Combine(basePath, "DAL.pfx");

                        listenOptions.Protocols = HttpProtocols.Http2;
                        listenOptions.UseHttps(certPath, "#o@kh)Ew7k!H%F%AprLyRQnjNG@w5A6R", httpsOptions =>
                        {
                            httpsOptions.ClientCertificateMode = ClientCertificateMode.RequireCertificate;
                        });
                    });
                })
                .UseStartup<Startup>();
    }
}