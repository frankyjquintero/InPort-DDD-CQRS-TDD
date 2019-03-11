using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.Repositories;
using InPort.Infra.Data.Context;
using InPort.Infra.Data.Test.Base;
using InPort.Infra.Data.UnitOfWork;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;

namespace InPort.Infra.Data.Test
{

    [Collection("QueryCollection")]
    public class GenericRepositoryTests
    {
        private readonly InPortDbContext _context;
        private readonly UnitOfWorkRepository _unitOfWork;

        public GenericRepositoryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _unitOfWork = fixture.UnitOfWork;
        }

        #region "GetAll"
        [Fact]
        public void GetAllTest()
        {
            //Arrange
            ICountryRepository countryRepository = _unitOfWork.CountryRepository;

            //Act
            IEnumerable<Country> countries = countryRepository.GetAll();

            //Assert
            List<Country> enumerable = countries.ToList();
            enumerable.ShouldNotBeNull();
            enumerable.Count.ShouldBe(2);
        }
        [Fact]
        public async Task GetAllAsycTest()
        {
            //Arrange
            ICountryRepository countryRepository = _unitOfWork.CountryRepository;

            //Act
            IEnumerable<Country> countries = await countryRepository.GetAllAsync();

            //Assert
            List<Country> enumerable = countries.ToList();
            enumerable.ShouldNotBeNull();
            enumerable.Count.ShouldBe(2);
        }
        #endregion

        #region  "Single"
        [Fact]
        public void SingleTest()
        {
            //Arrange
            ICountryRepository countryRepository = _unitOfWork.CountryRepository;
            Guid countryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");

            //Act
            Country country = countryRepository.Single(e => e.Id == countryId);

            //Assert
            country.ShouldNotBeNull();
            country.Id.ShouldBe(countryId);
        }
        [Fact]
        public async Task SingleAsycTest()
        {
            //Arrange
            ICountryRepository countryRepository = _unitOfWork.CountryRepository;
            Guid countryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");

            //Act
            Country country = await countryRepository.SingleAsync(e => e.Id == countryId);

            //Assert
            country.ShouldNotBeNull();
            country.Id.ShouldBe(countryId);
        }
        [Fact]
        public void SingleOrDefaultTest()
        {
            //Arrange
            ICountryRepository countryRepository = _unitOfWork.CountryRepository;
            Guid countryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");

            //Act
            Country country = countryRepository.SingleOrDefault(e => e.Id == countryId);

            //Assert
            country.ShouldNotBeNull();
            country.Id.ShouldBe(countryId);
        }
        [Fact]
        public async Task SingleOrDefaultAsycTest()
        {
            //Arrange
            ICountryRepository countryRepository = _unitOfWork.CountryRepository;
            Guid countryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");

            //Act
            Country country = await countryRepository.SingleOrDefaultAsync(e => e.Id == countryId);

            //Assert
            country.ShouldNotBeNull();
            country.Id.ShouldBe(countryId);
        }
        #endregion

        #region "First"
        [Fact]
        public void FirstTest()
        {
            //Arrange
            ICountryRepository countryRepository = _unitOfWork.CountryRepository;
            Guid countryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");

            //Act
            Country country = countryRepository.First(e => e.Id == countryId);

            //Assert
            country.ShouldNotBeNull();
            country.Id.ShouldBe(countryId);
        }
        [Fact]
        public async Task FirstAsycTest()
        {
            //Arrange
            ICountryRepository countryRepository = _unitOfWork.CountryRepository;
            Guid countryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");

            //Act
            Country country = await countryRepository.SingleAsync(e => e.Id == countryId);

            //Assert
            country.ShouldNotBeNull();
            country.Id.ShouldBe(countryId);
        }
        [Fact]
        public void FirstOrDefaultTest()
        {
            //Arrange
            ICountryRepository countryRepository = _unitOfWork.CountryRepository;
            Guid countryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");

            //Act
            Country country = countryRepository.FirstOrDefault(e => e.Id == countryId);

            //Assert
            country.ShouldNotBeNull();
            country.Id.ShouldBe(countryId);
        }
        [Fact]
        public async Task FirstOrDefaultAsycTest()
        {
            //Arrange
            ICountryRepository countryRepository = _unitOfWork.CountryRepository;
            Guid countryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");

            //Act
            Country country = await countryRepository.FirstOrDefaultAsync(e => e.Id == countryId);

            //Assert
            country.ShouldNotBeNull();
            country.Id.ShouldBe(countryId);
        }
        #endregion


    }
}
