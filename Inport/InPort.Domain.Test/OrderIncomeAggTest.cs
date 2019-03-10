using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.AggregatesModel.MeasurentUnitAgg;
using InPort.Domain.AggregatesModel.OrderIncomeAgg;
using InPort.Domain.AggregatesModel.ProductAgg;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace InPort.Domain.Test
{
    [Collection("OrderIncomeAggCollection")]
    public class OrderIncomeAggTest
    {
        private readonly Country _country;
        private readonly Customer _customer;
        private readonly List<Product> _products = new List<Product>();
        public OrderIncomeAggTest()
        {
            OrderIncome order = new OrderIncome(); //Constructor EF
            string lastName = "El rojo";
            string firstName = "Jhon";
            string telephone = "+34111111";
            string company = "company name";

            _country = CountryFactory.CreateCountry("Spain", "es-ES");

            _customer = CustomerFactory.CreateCustomer(firstName, lastName, telephone, company, "email@email.com", _country, new Address("city", "zipcode", "AddressLine1", "AddressLine2"));

            for (int i = 0; i < 5; i++)
            {
                Product prod = ProductFactory.CreateProduct("product" + i, "description" + i);
                _products.Add(prod);
            }
        }

        [Fact]
        public void AddOrderItemOk()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");

            MeasurentUnit measurentUnit = MeasurentUnitFactory.CreateMeasurentUnit(MeasurentUnitType.Longitud, "Litro");
            //Act(Actuar)
            Product product = _products.First();
            int amount = 1;
            order.AddOrderItem(product, measurentUnit, amount);

            //Assert(Afirmar)
            order.OrderIncomeLines.Count.ShouldBe(1);

            OrderIncomeLine xline = order.OrderIncomeLines
                .SingleOrDefault(o => (o.ProductId == product.Id && o.MeasurentUnitId == measurentUnit.Id));

            xline.ShouldNotBeNull();
            
            xline?.ProductId.ShouldBe(product.Id);
            xline?.Amount.ShouldBe(amount);

        }
        [Fact]
        public void AddOrderItemExistSumAmountOk()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");

            MeasurentUnit measurentUnit = MeasurentUnitFactory.CreateMeasurentUnit(MeasurentUnitType.Longitud, "Litro");
            //Act(Actuar)
            Product product = _products.First();
            int amount = 2;
            order.AddOrderItem(product, measurentUnit, amount);
            order.AddOrderItem(product, measurentUnit, amount);

            //Assert(Afirmar)
            order.OrderIncomeLines.Count.ShouldBe(1);

            OrderIncomeLine xline = order.OrderIncomeLines
                .SingleOrDefault(o => (o.ProductId == product.Id && o.MeasurentUnitId == measurentUnit.Id));

            xline.ShouldNotBeNull();

            xline?.ProductId.ShouldBe(product.Id);
            xline?.Amount.ShouldBe(amount + amount);

        }
        [Fact]
        public void SetTheCustomerForThisOrderOk()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");
            string lastName = "El rojo";
            string firstName = "Jhon";
            string telephone = "+34111111";
            string company = "company name";

            Customer customernew = CustomerFactory.CreateCustomer(firstName, lastName, telephone, company, "email@email.com", _country, new Address("city", "zipcode", "AddressLine1", "AddressLine2"));
            //Act(Actuar)
            order.CustomerId.ShouldBe(_customer.Id);
            order.SetTheCustomerForThisOrder(customernew);
            //Assert(Afirmar)
            order.CustomerId.ShouldBe(customernew.Id);
        }
        [Fact]
        public void SetTheCustomerForThisOrderFail()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");
            string lastName = "El Negro";
            string firstName = "Alex";
            string telephone = "+34111111";
            string company = "company name";

            Customer customernew = CustomerFactory.CreateCustomer(firstName, lastName, telephone, company, "email@email.com", _country, new Address("city", "zipcode", "AddressLine1", "AddressLine2"));
            //Act(Actuar)
            order.CustomerId.ShouldBe(_customer.Id);

            //Assert(Afirmar)
            Should.Throw<Exception>(() =>
            {
                order.SetTheCustomerForThisOrder(null);
            });
        }
        [Fact]
        public void SetTheCustomerReferenceForThisOrderOk()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");
            string lastName = "El rojo";
            string firstName = "Jhon";
            string telephone = "+34111111";
            string company = "company name";

            Customer customernew = CustomerFactory.CreateCustomer(firstName, lastName, telephone, company, "email@email.com", _country, new Address("city", "zipcode", "AddressLine1", "AddressLine2"));
            //Act(Actuar)
            order.CustomerId.ShouldBe(_customer.Id);
            order.SetTheCustomerReferenceForThisOrder(customernew.Id);
            //Assert(Afirmar)
            order.CustomerId.ShouldBe(customernew.Id);
        }
        [Fact]
        public void SetTheCustomerReferenceForThisOrderFail()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");
            string lastName = "El Negro";
            string firstName = "Alex";
            string telephone = "+34111111";
            string company = "company name";

            Customer customernew = CustomerFactory.CreateCustomer(firstName, lastName, telephone, company, "email@email.com", _country, new Address("city", "zipcode", "AddressLine1", "AddressLine2"));
            //Act(Actuar)
            order.CustomerId.ShouldBe(_customer.Id);

            //Assert(Afirmar)
            Should.Throw<Exception>(() =>
            {
                order.SetTheCustomerReferenceForThisOrder(Guid.Empty);
            });
        }
        [Fact]
        public void SetRegistroBitacoraStatusOk()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");
            //Act(Actuar)
            order.SetRegistroBitacoraStatus();
            //Assert(Afirmar)
            order.OrderIncomeStatusId.ShouldBe(OrderIncomeStatus.RegistroBitacora.Id);
        }
        [Fact]
        public void SetDianStatusOk()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");
            //Act(Actuar)
            order.SetRegistroBitacoraStatus();
            order.SetDianStatus();
            //Assert(Afirmar)
            order.OrderIncomeStatusId.ShouldBe(OrderIncomeStatus.Dian.Id);
        }
        [Fact]
        public void SetVerificacionBitacoraStatusOk()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");
            //Act(Actuar)
            order.SetRegistroBitacoraStatus();
            order.SetDianStatus();
            order.SetVerificacionBitacoraStatus();
            //Assert(Afirmar)
            order.OrderIncomeStatusId.ShouldBe(OrderIncomeStatus.VerificacionBitacora.Id);
        }
        [Fact]
        public void SetCompletadoStatusOk()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");
            //Act(Actuar)
            order.SetRegistroBitacoraStatus();
            order.SetDianStatus();
            order.SetVerificacionBitacoraStatus();
            order.SetCompletadoStatus();
            //Assert(Afirmar)
            order.OrderIncomeStatusId.ShouldBe(OrderIncomeStatus.Completado.Id);
        }
        [Fact]
        public void SetRegistroBitacoraStatusFail()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");
            //Act(Actuar)
            order.SetRegistroBitacoraStatus();

            //Assert(Afirmar)
            Should.Throw<Exception>(() =>
            {
                order.SetRegistroBitacoraStatus();
            });

        }
        [Fact]
        public void SetDianStatusFail()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");
            //Act(Actuar)
            // No se hacen los Estados previos

            //Assert(Afirmar)
            Should.Throw<Exception>(() =>
            {
                order.SetDianStatus();
            });

        }
        [Fact]
        public void SetVerificacionBitacoraStatusFail()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");

            //Act(Actuar)
            // No se hacen los Estados previos

            //Assert(Afirmar)
            Should.Throw<Exception>(() =>
            {
                order.SetVerificacionBitacoraStatus();
            });
        }
        [Fact]
        public void SetCompletadoStatusFail()
        {
            //Arrange(Preparar)
            OrderIncome order = OrderFactory.CreateOrder(_customer, "", "", "");
            //Act(Actuar)
            // No se hacen los Estados previos

            //Assert(Afirmar)
            Should.Throw<Exception>(() =>
            {
                order.SetCompletadoStatus();
            });
        }

    }
}
