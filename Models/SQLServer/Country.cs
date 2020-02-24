using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace DAL.Models.SQLServer
{
    [ServiceContract]
    public interface ICountry
    {
        ValueTask<List<Country>> GetAllAsync();
    }

    [Table("Countries")]
    [DataContract]
    public class Country
    {
        [Key]
        [DataMember(Order = 1)]
        public int CountryId { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
    }
}
