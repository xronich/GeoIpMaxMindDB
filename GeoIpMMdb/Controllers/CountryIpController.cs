using GeoIp.Implementation;
using GeoIp.Models;
using GeoIpMMdb.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;

namespace GeoIp.Controllers
{
    [ApiController]
    [Route("api/country")]
    public class CountryIpController : ControllerBase
    {
        private readonly ILogger<CountryIpController> _logger;
        private readonly GeoLite2Data _geoLite2Data;

        public CountryIpController(IOptions<GeoLite2Data> geoLite2DataProvider, ILogger<CountryIpController> logger)
        {
            _geoLite2Data = geoLite2DataProvider.Value;
            _logger = logger;
        }

        [HttpGet]
        public CountryDataModel Get(string ip)
        {
            if (!IPAddress.TryParse(ip, out var ipAddr))
                throw new GeoIpException("Failed parse ip");


            var data = _geoLite2Data.GetDataByIp(ipAddr);

            return data;
        }
    }
}
