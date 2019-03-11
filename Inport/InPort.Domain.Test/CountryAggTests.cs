using InPort.Domain.AggregatesModel.CountryAgg;
using System;
using Xunit;

namespace InPort.Domain.Test
{
    public class CountryAggTests
    {
        [Fact]
        public void CannotCreateCountryWithNullName()
        {
            //Arrange and Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => { var country = new Country(null, "es-ES"); });
            Assert.IsType<ArgumentNullException>(ex);
        }
        [Fact]
        public void CannotCreateCountryWithNullIsoCode()
        {
            //Arrange and Act            
            Exception ex = Assert.Throws<ArgumentNullException>(() => { var country = new Country("spain", null); });
            Assert.IsType<ArgumentNullException>(ex);
        }
        [Fact]
        public void CannotCreateCountryWithEmptyName()
        {
            //Arrange and Act            
            Exception ex = Assert.Throws<ArgumentNullException>(() => { var country = new Country(string.Empty, "es-ES"); });
            Assert.IsType<ArgumentNullException>(ex);
        }
        [Fact]
        public void CannotCreateCountryWithEmptyIsoCode()
        {
            //Arrange and Act            
            Exception ex = Assert.Throws<ArgumentNullException>(() => { var country = new Country("spain", string.Empty); });
            Assert.IsType<ArgumentNullException>(ex);
        }
        [Fact]
        public void CannotCreateCountryWithWhitespaceName()
        {
            //Arrange and Act            
            Exception ex = Assert.Throws<ArgumentNullException>(() => { var country = new Country(" ", "es-ES"); });
            Assert.IsType<ArgumentNullException>(ex);
        }
        [Fact]
        public void CannotCreateCountryWithWhitespaceIsoCode()
        {
            //Arrange and Act            
            Exception ex = Assert.Throws<ArgumentNullException>(() => { var country = new Country("spain", " "); });
            Assert.IsType<ArgumentNullException>(ex);
        }
    }
}
