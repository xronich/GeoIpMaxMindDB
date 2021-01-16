# GeoIpMaxMindDB

Get CountryCode, CountryName, PhoneCode from ip address.

Actual MaxMindDB date: 11/24/2020

For update database:
- Download new GeoLite2 Country file from https://www.maxmind.com/
- Update path to file appsettings.json or replace existing GeoLite2-Country.mmdb

# Web Api
- GET /api​/country

Response model:
{
  "countryCode": "string",
  "countryName": "string",
  "phoneCode": "string"
}

Example: https://localhost:44394/api/country?ip=8.8.4.4