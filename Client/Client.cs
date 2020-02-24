using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace DAL
{
    public class Client : IDisposable
    {
        private GrpcChannel Channel { get; set; }
        public DAL.Methods.Country Country { get; set; }
        public Client(string address)
        {
            var basePath = Path.GetDirectoryName(typeof(Client).Assembly.Location);
            var certPath = Path.Combine(basePath, "DAL.pfx");
            var clientCertificate = new X509Certificate2(certPath, "#o@kh)Ew7k!H%F%AprLyRQnjNG@w5A6R");

            GrpcClientFactory.AllowUnencryptedHttp2 = false;
            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            httpClientHandler.ClientCertificates.Add(clientCertificate);
            var httpClient = new HttpClient(httpClientHandler);
            
            Channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions()
            {
                HttpClient = httpClient
            });

            Country = new DAL.Methods.Country(Channel);
        }

        public void Dispose()
        {
            Channel.Dispose();
        }
    }
}
