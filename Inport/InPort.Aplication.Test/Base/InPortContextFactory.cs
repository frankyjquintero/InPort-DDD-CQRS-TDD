using System;
using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InPort.Aplication.Test.Base
{
    public class InPortContextFactory
    {
        public static InPortDbContext Create()
        {
            var options = new DbContextOptionsBuilder<InPortDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new InPortDbContext(options);

            context.Database.EnsureCreated();

            Seed(context);

            context.SaveChanges();

            return context;
        }


        protected static void Seed(InPortDbContext unitOfWork)
        {
            /*
             * Countries agg
             */

            var spainCountry = new Country("Spain", "es-ES");
            spainCountry.ChangeCurrentIdentity(new Guid("32BB805F-40A4-4C37-AA96-B7945C8C385C"));

            var usaCountry = new Country("EEUU", "en-US");
            usaCountry.ChangeCurrentIdentity(new Guid("C3C82D06-6A07-41FB-B7EA-903EC456BFC5"));

            unitOfWork.Countries.Add(spainCountry);
            unitOfWork.Countries.Add(usaCountry);

            /*
             * Customers agg
             */

            var customerJhon = CustomerFactory.CreateCustomer("Jhon", "Jhon", "+34617", "company", "Email@mail.com",spainCountry, new Address("Madrid", "280181", "Paseo de La finca", ""));
            customerJhon.ChangeCurrentIdentity(new Guid("43A38AC8-EAA9-4DF0-981F-2685882C7C45"));


            var customerMay = CustomerFactory.CreateCustomer("May", "Garcia", "+34617", "company", "Email@mail.com", usaCountry, new Address("Seatle", "3332", "Alaskan Way", ""));
            customerMay.ChangeCurrentIdentity(new Guid("0CD6618A-9C8E-4D79-9C6B-4AA69CF18AE6"));


            unitOfWork.Customers.Add(customerJhon);
            unitOfWork.Customers.Add(customerMay);


            unitOfWork.SaveChanges();
        }

        public static void Destroy(InPortDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
