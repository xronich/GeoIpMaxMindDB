using GeoIp.Models;
using GeoIpMMdb.Configuration;
using MaxMind.Db;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Linq;
using System.Net;

namespace GeoIp.Implementation
{
    public class GeoLite2Data
    {
        private Reader GeoIpReader;
        public GeoLite2Data(string filePath)
        {
            GeoIpReader = new Reader(filePath);
        }

        public CountryDataModel GetDataByIp(IPAddress ip)
        {
            var data = GeoIpReader.Find<object>(ip);

            var json = JsonConvert.SerializeObject(data);
            var geoLite2CountryData = JsonConvert.DeserializeObject<GeoLite2CountryModel>(json);

            var countryCode = geoLite2CountryData.country.iso_code;
            var countryName = geoLite2CountryData.country.names.en;
            var phoneCode = CountryTelCodeData.TelCodes.Where(tel => tel.Iso == countryCode).FirstOrDefault()?.Pfx;

            return new CountryDataModel
            {
                CountryCode = countryCode,
                CountryName = countryName,
                PhoneCode = phoneCode
            };
        }
    }
}
