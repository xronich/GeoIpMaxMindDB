using GeoIp.Models;
using MaxMind.Db;
using Newtonsoft.Json;
using System.Linq;
using System.Net;

namespace GeoIp.Implementation
{
    public static class GeoLite2Data
    {
        public static Reader GeoIpReader;

        static GeoLite2Data()
        {
            GeoIpReader = new Reader("GeoLite2-Country.mmdb");
        }

        public static CountryDataModel GetDataByIp(IPAddress ip)
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
