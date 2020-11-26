using Newtonsoft.Json;

namespace GeoIp.Models
{
    public class Names
    {
        public string de { get; set; }
        public string en { get; set; }
        public string es { get; set; }
        public string fr { get; set; }
        public string ja { get; set; }
        [JsonProperty("pt-BR")]
        public string PtBR { get; set; }
        public string ru { get; set; }
        [JsonProperty("zh-CN")]
        public string ZhCN { get; set; }
    }

    public class Continent
    {
        public string code { get; set; }
        public int geoname_id { get; set; }
        public Names names { get; set; }
    }

    public class Names2
    {
        public string de { get; set; }
        public string en { get; set; }
        public string es { get; set; }
        public string fr { get; set; }
        public string ja { get; set; }
        [JsonProperty("pt-BR")]
        public string PtBR { get; set; }
        public string ru { get; set; }
        [JsonProperty("zh-CN")]
        public string ZhCN { get; set; }
    }

    public class Country
    {
        public int geoname_id { get; set; }
        public string iso_code { get; set; }
        public Names2 names { get; set; }
    }

    public class Names3
    {
        public string de { get; set; }
        public string en { get; set; }
        public string es { get; set; }
        public string fr { get; set; }
        public string ja { get; set; }
        [JsonProperty("pt-BR")]
        public string PtBR { get; set; }
        public string ru { get; set; }
        [JsonProperty("zh-CN")]
        public string ZhCN { get; set; }
    }

    public class RegisteredCountry
    {
        public int geoname_id { get; set; }
        public string iso_code { get; set; }
        public Names3 names { get; set; }
    }

    public class GeoLite2CountryModel
    {
        public Continent continent { get; set; }
        public Country country { get; set; }
        public RegisteredCountry registered_country { get; set; }
    }
}
