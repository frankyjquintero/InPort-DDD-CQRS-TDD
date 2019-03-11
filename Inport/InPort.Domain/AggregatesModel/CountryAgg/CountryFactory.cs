namespace InPort.Domain.AggregatesModel.CountryAgg
{
    public static class CountryFactory
    {
        public static Country CreateCountry(string countryName, string isoCode)
        {
            //crear nueva instancia y establecer identidad
            var country = new Country(countryName, isoCode);

            country.GenerateNewIdentity();
        

            return country;
        }
    }
}
