﻿using System;
using MediatR;

namespace InPort.Aplication.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string AddressCity { get; set; }
        public string AddressZipCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public Guid CountryId { get; set; }
        public byte[] PictureByte { get; set; }

    }
}
