using DAL.Models.SQLServer;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Methods
{
    public class Country
    {
        private GrpcChannel Channel { get; set; }
        public Country(GrpcChannel channel)
        {
            this.Channel = channel;
        }

        public async Task<List<Models.SQLServer.Country>> GetAllAsync()
        {
            var service = Channel.CreateGrpcService<ICountry>();
            return await service.GetAllAsync();
        }
    }
}
