using InPort.Aplication.Core.Commands;
using MediatR;
using System;

namespace InPort.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string AddressCity { get; set; }
        public string AddressZipCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CountryId { get; set; }
    }
}
