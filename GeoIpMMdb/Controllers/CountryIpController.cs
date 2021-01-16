using GeoIp.Implementation;
using GeoIp.Models;
using GeoIpMMdb.Configuration;
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
        private readonly MMDBConfiguration _MMDBConfiguration;

        public CountryIpController(IOptions<MMDBConfiguration> MMDBConfigurationProvider, ILogger<CountryIpController> logger)
        {
            _MMDBConfiguration = MMDBConfigurationProvider.Value;
            _logger = logger;
        }

        [HttpGet]
        public CountryDataModel Get(string ip)
        {
            if (!IPAddress.TryParse(ip, out var ipAddr))
                throw new GeoIpException("Failed parse ip");

            var data = new GeoLite2Data(_MMDBConfiguration.FilePath).GetDataByIp(ipAddr);

            return data;
        }
    }
}
