using GeoIp.Implementation;
using GeoIp.Models;
using GeoIpMMdb.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace GeoIp.Controllers
{
    [ApiController]
    [Route("api/country")]
    public class CountryIpController : ControllerBase
    {
        private readonly ILogger<CountryIpController> _logger;

        public CountryIpController(ILogger<CountryIpController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public CountryDataModel Get(string ip)
        {
            if (!IPAddress.TryParse(ip, out var ipAddr))
                throw new GeoIpException("Failed parse ip");


            var data = GeoLite2Data.GetDataByIp(ipAddr);

            return data;
        }
    }
}
