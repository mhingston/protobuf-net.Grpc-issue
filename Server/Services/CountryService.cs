using DAL.Models.SQLServer;
using DAL.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class CountryService : ICountry
    {
        private SqlServerContext msDb { get; set; }
        public CountryService(SqlServerContext msDb)
        {
            this.msDb = msDb;
        }

        ValueTask<List<Country>> ICountry.GetAllAsync()
        {
            var countries = msDb.Country.ToList();
            return new ValueTask<List<Country>>(countries);
        }
    }
}
