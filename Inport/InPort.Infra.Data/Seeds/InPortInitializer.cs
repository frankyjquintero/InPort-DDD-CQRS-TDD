using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Infra.Data.Context;
using System.Linq;

namespace InPort.Infra.Data.Seeds
{
    public class InPortInitializer
    {
        public static void Initialize(InPortDbContext context)
        {
            InPortInitializer initializer = new InPortInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(InPortDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return; // Db has been seeded
            }

            SeedCustomers(context);


        }

        public void SeedCustomers(InPortDbContext context)
        {
            //Countries
            var spain = new Country("Spain", "ES");
            spain.GenerateNewIdentity();
            context.Countries.Add(spain);

            var us = new Country("U.S.", "US");
            us.GenerateNewIdentity();
            context.Countries.Add(us);

            var uk = new Country("U.K.", "GB");
            uk.GenerateNewIdentity();
            context.Countries.Add(uk);

            var canada = new Country("Canada", "CA");
            canada.GenerateNewIdentity();
            context.Countries.Add(canada);

            var italy = new Country("Italy", "IT");
            italy.GenerateNewIdentity();
            context.Countries.Add(italy);

            var france = new Country("France", "FR");
            france.GenerateNewIdentity();
            context.Countries.Add(france);

            var argentina = new Country("Argentina", "AR");
            argentina.GenerateNewIdentity();
            context.Countries.Add(argentina);

            var russia = new Country("Russian Federation", "RUS");
            russia.GenerateNewIdentity();
            context.Countries.Add(russia);

            var israel = new Country("Israel", "IS");
            israel.GenerateNewIdentity();
            context.Countries.Add(israel);

            var brazil = new Country("Brazil", "BZ");
            brazil.GenerateNewIdentity();
            context.Countries.Add(brazil);

            ////
            //Customers

            //Cesar Torres
            var customer1 = CustomerFactory.CreateCustomer("Cesar", "Torres", "+34 1234567", "Microsoft", "email1@email.com", spain, new Address("Madrid", "28700", "Calle Club Deportivo 1", "Parque Empresarial La Finca, Edif. 1"));
            customer1.SetTheCountryReference(spain.Id);
            context.Customers.Add(customer1);

            //Unai Zorrilla
            var customer2 = CustomerFactory.CreateCustomer("Unai", "Zorrilla", "+34 1234567", "Plain Concepts", "email2@email.com", spain, new Address("Madrid", "12345", "Calle Plain", "Barrio San Chinarro"));
            customer2.SetTheCountryReference(spain.Id);
            context.Customers.Add(customer2);

            //Miguel Angel
            var customer3 = CustomerFactory.CreateCustomer("Miguel Angel", "Ramos", "+1 1234567", "Microsoft", "email3@email.com", us, new Address("Redmond", "12345", "One Microsoft Way", "Building X"));
            customer3.SetTheCountryReference(us.Id);
            context.Customers.Add(customer3);

            //Erica Vansas          
            var customer4 = CustomerFactory.CreateCustomer("Erica", "Vansas", "+1 1234567", "Domain Language", "email4@email.com", us, new Address("City", "12345", "DDD Street", "Building X"));
            customer4.SetTheCountryReference(us.Id);
            context.Customers.Add(customer4);

            //César Castro            
            var customer5 = CustomerFactory.CreateCustomer("César", "Castro", "+34 1234567", "Freelance", "email5@email.com", spain, new Address("Madrid", "12345", "Calle de Madrid", "Barrio de Madrid"));
            customer5.SetTheCountryReference(spain.Id);
            context.Customers.Add(customer5);

            context.SaveChanges();
        }

    }
}
