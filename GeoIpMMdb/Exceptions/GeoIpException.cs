using System;

namespace GeoIpMMdb.Exceptions
{
    public class GeoIpException: Exception
	{
		public GeoIpException(string message): base(message)
		{
		}
	}
}
