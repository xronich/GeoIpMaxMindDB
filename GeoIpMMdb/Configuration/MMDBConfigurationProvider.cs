using Microsoft.Extensions.Options;

namespace GeoIpMMdb.Configuration
{
    public class MMDBConfigurationInject
    {
        MMDBConfigurationProvider _emailProvider;
        public string FilePath => _emailProvider.FilePath;
        public MMDBConfigurationInject(IOptions<MMDBConfigurationProvider> emailProviderAccessor)
        {
            _emailProvider = emailProviderAccessor.Value;
        }

    }
}
