using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.Repositories;
using InPort.Infra.Data.Context;
using InPort.Infra.Data.Test.Base;
using InPort.Infra.Data.UnitOfWork;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace InPort.Infra.Data.Test
{

    [Collection("QueryCollection")]
    public class GenericRepositoryTests
    {
        private readonly InPortDbContext _context;
        private readonly UnitOfWorkContainer _unitOfWork;

        public GenericRepositoryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _unitOfWork = fixture.UnitOfWork;
        }

        #region Extras
        [Fact]
        public void CountTest()
        {
            //Arrange
            ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;

            //Act
            int count = countryRepository.Count();

            //Assert
            count.ShouldBe(2);
        }
        [Fact]
        public async Task CountAsycTest()
        {
            //Arrange
            ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;

            //Act
            int count = await countryRepository.CountAsync();

            //Assert
            count.ShouldBe(2);
        }

        //[Fact]
        //public void SumTest()
        //{
        //    //Arrange
        //    ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;
        //    Guid countryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");
        //    //Act
        //    decimal? count = countryRepository.Sum(e => e.Id == countryId);

        //    //Assert
        //    //count.ShouldBe(2);
        //}
        //[Fact]
        //public async Task SumAsycTest()
        //{
        //    //Arrange
        //    ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;

        //    //Act
        //    decimal? count = await countryRepository.SumAsync();

        //    //Assert
        //    //count.ShouldBe(2);
        //}

        #endregion

        #region "GetAll"
        [Fact]
        public void GetAllTest()
        {
            //Arrange
            ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;

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
            ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;

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
            ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;
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
            ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;
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
            ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;
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
            ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;
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
            ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;
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
            ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;
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
            ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;
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
            ICountryRepository countryRepository = _unitOfWork.Repository.CountryRepository;
            Guid countryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");

            //Act
            Country country = await countryRepository.FirstOrDefaultAsync(e => e.Id == countryId);

            //Assert
            country.ShouldNotBeNull();
            country.Id.ShouldBe(countryId);
        }
        #endregion


        #region Add
        [Fact]
        public void AddTest()
        {
            //Arrange
            InPortDbContext context = InPortContextFactory.Create();
            UnitOfWorkContainer unitwork = new UnitOfWorkContainer(context);
            ICountryRepository countryRepository = unitwork.Repository.CountryRepository;

            Guid countryId = new Guid("F3C82D06-6A07-41FB-B7EA-903EC456BFC5");
            Country country1 = new Country("Colombia", "CO");
            country1.ChangeCurrentIdentity(countryId);

            //Act
            countryRepository.Add(country1);
            unitwork.SaveChanges();

            Country country = countryRepository.Single(e => e.Id == countryId);

            //Assert
            country.ShouldNotBeNull();
            country.CountryName.ShouldBe("Colombia");
            country.CountryISOCode.ShouldBe("CO");
            country.Id.ShouldBe(countryId);
        }
        [Fact]
        public async Task AddAsycTest()
        {
            //Arrange
            InPortDbContext context = InPortContextFactory.Create();
            UnitOfWorkContainer unitwork = new UnitOfWorkContainer(context);
            ICountryRepository countryRepository = unitwork.Repository.CountryRepository;

            Guid countryId = new Guid("A3C82D06-6A07-41FB-B7EA-903EC456BFC5");
            Country country2 = new Country("Colombia", "CO");
            country2.ChangeCurrentIdentity(countryId);

            //Act
            await countryRepository.AddAsync(country2);
            await unitwork.SaveChangesAsync();

            Country country = await countryRepository.SingleAsync(e => e.Id == countryId);

            //Assert
            country.ShouldNotBeNull();
            country.CountryName.ShouldBe("Colombia");
            country.CountryISOCode.ShouldBe("CO");
            country.Id.ShouldBe(countryId);
        }
        [Fact]
        public void AddRangeTest()
        {
            //Arrange
            InPortDbContext context = InPortContextFactory.Create();
            UnitOfWorkContainer unitwork = new UnitOfWorkContainer(context);
            ICountryRepository countryRepository = unitwork.Repository.CountryRepository;

            Guid countryId1 = new Guid("A3C82D06-6A07-41FB-B7EA-903EC456BFC5");
            Country country1 = new Country("Colombia", "CO");
            country1.ChangeCurrentIdentity(countryId1);

            Guid countryId2 = new Guid("B3C82D06-6A07-41FB-B7EA-903EC456BFC5");
            Country country2 = new Country("Venezuela", "VZ");
            country2.ChangeCurrentIdentity(countryId2);

            List<Country> list = new List<Country>()
            {
                country1,
                country2
            };

            //Act
            countryRepository.Add(list);
            unitwork.SaveChanges();

            Country countryF1 = countryRepository.Single(e => e.Id == countryId1);
            Country countryF2 = countryRepository.Single(e => e.Id == countryId2);

            //Assert
            countryF1.ShouldNotBeNull();
            countryF1.CountryName.ShouldBe("Colombia");
            countryF1.CountryISOCode.ShouldBe("CO");
            countryF1.Id.ShouldBe(countryId1);

            countryF2.ShouldNotBeNull();
            countryF2.CountryName.ShouldBe("Venezuela");
            countryF2.CountryISOCode.ShouldBe("VZ");
            countryF2.Id.ShouldBe(countryId2);
        }
        [Fact]
        public async Task AddRangeAsycTest()
        {
            //Arrange
            InPortDbContext context = InPortContextFactory.Create();
            UnitOfWorkContainer unitwork = new UnitOfWorkContainer(context);
            ICountryRepository countryRepository = unitwork.Repository.CountryRepository;

            Guid countryId1 = new Guid("A3C82D06-6A07-41FB-B7EA-903EC456BFC5");
            Country country1 = new Country("Colombia", "CO");
            country1.ChangeCurrentIdentity(countryId1);

            Guid countryId2 = new Guid("B3C82D06-6A07-41FB-B7EA-903EC456BFC5");
            Country country2 = new Country("Venezuela", "VZ");
            country2.ChangeCurrentIdentity(countryId2);

            List<Country> list = new List<Country>()
            {
                country1,
                country2
            };

            //Act
            await countryRepository.AddAsync(list);
            await unitwork.SaveChangesAsync();

            Country countryF1 = await countryRepository.SingleAsync(e => e.Id == countryId1);
            Country countryF2 = await countryRepository.SingleAsync(e => e.Id == countryId2);

            //Assert
            countryF1.ShouldNotBeNull();
            countryF1.CountryName.ShouldBe("Colombia");
            countryF1.CountryISOCode.ShouldBe("CO");
            countryF1.Id.ShouldBe(countryId1);

            countryF2.ShouldNotBeNull();
            countryF2.CountryName.ShouldBe("Venezuela");
            countryF2.CountryISOCode.ShouldBe("VZ");
            countryF2.Id.ShouldBe(countryId2);
        }

        #endregion


        #region  Remove
        [Fact]
        public void RemoveTest()
        {
            //Arrange
            InPortDbContext context = InPortContextFactory.Create();
            UnitOfWorkContainer unitwork = new UnitOfWorkContainer(context);
            ICountryRepository countryRepository = unitwork.Repository.CountryRepository;

            Guid countryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");

            //Act
            Country country = countryRepository.Single(e => e.Id == countryId);

            countryRepository.Remove(country);
            unitwork.SaveChanges();

            Country countryF = countryRepository.SingleOrDefault(e => e.Id == countryId);
            //Assert
            countryF.ShouldBeNull();

        }
        [Fact]
        public void RemoveRangeTest()
        {
            //Arrange
            InPortDbContext context = InPortContextFactory.Create();
            UnitOfWorkContainer unitwork = new UnitOfWorkContainer(context);
            ICountryRepository countryRepository = unitwork.Repository.CountryRepository;

            Guid countryId1 = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");
            Guid countryId2 = new Guid("C3C82D06-6A07-41FB-B7EA-903EC456BFC5");

            //Act
            Country country1 = countryRepository.Single(e => e.Id == countryId1);
            Country country2 = countryRepository.Single(e => e.Id == countryId2);

            List<Country> list = new List<Country>()
            {
                country1,
                country2
            };
            countryRepository.Remove(list);
            unitwork.SaveChanges();

            Country countryF1 = countryRepository.SingleOrDefault(e => e.Id == countryId1);
            Country countryF2 = countryRepository.SingleOrDefault(e => e.Id == countryId2);
            //Assert
            countryF1.ShouldBeNull();
            countryF2.ShouldBeNull();
        }

        #endregion

        #region  Remove
        [Fact]
        public void UpdateTest()
        {
            //Arrange
            InPortDbContext context = InPortContextFactory.Create();
            UnitOfWorkContainer unitwork = new UnitOfWorkContainer(context);
            ICountryRepository countryRepository = unitwork.Repository.CountryRepository;

            Guid countryId = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");
            // "Spain", "es-ES"

            //Act
            Country country = countryRepository.Single(e => e.Id == countryId);
            country.SetName("Venezuela");
            country.SetIsoCode("VZ");
            countryRepository.Update(country);
            unitwork.SaveChanges();

            Country countryF = countryRepository.SingleOrDefault(e => e.Id == countryId);
            //Assert
            countryF.ShouldNotBeNull();
            countryF.CountryName.ShouldBe("Venezuela");
            countryF.CountryISOCode.ShouldBe("VZ");

        }
        [Fact]
        public void UpdateRangeTest()
        {
            //Arrange
            InPortDbContext context = InPortContextFactory.Create();
            UnitOfWorkContainer unitwork = new UnitOfWorkContainer(context);
            ICountryRepository countryRepository = unitwork.Repository.CountryRepository;

            Guid countryId1 = new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C");
            // "Spain", "es-ES"
            Guid countryId2 = new Guid("C3C82D06-6A07-41FB-B7EA-903EC456BFC5");
            // "EEUU", "en-US"

            //Act
            Country country1 = countryRepository.Single(e => e.Id == countryId1);
            country1.SetName("Venezuela");
            country1.SetIsoCode("VZ");
            Country country2 = countryRepository.Single(e => e.Id == countryId2);
            country1.SetName("Brazil");
            country1.SetIsoCode("Br");

            List<Country> list = new List<Country>()
            {
                country1,
                country2
            };
            countryRepository.Update(list);
            unitwork.SaveChanges();

            Country countryF1 = countryRepository.SingleOrDefault(e => e.Id == countryId1);
            Country countryF2 = countryRepository.SingleOrDefault(e => e.Id == countryId2);
            //Assert
            countryF1.ShouldNotBeNull();
            countryF1.CountryName.ShouldBe("Venezuela");
            countryF1.CountryISOCode.ShouldBe("VZ");
            countryF2.ShouldNotBeNull();
            countryF2.CountryName.ShouldBe("Brazil");
            countryF2.CountryISOCode.ShouldBe("Br");
        }

        #endregion

    }
}
