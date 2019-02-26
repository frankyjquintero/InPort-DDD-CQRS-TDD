using InPort.Aplication.Core.Commands;
using InPort.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Aplication.Customers.Commands
{
    public abstract class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string Telephone { get; protected set; }
        public string Company { get; protected set; }
        public string Email { get; protected set; }

        public string AddressCity { get; protected set; }

        public string AddressZipCode { get; protected set; }


        public string AddressLine1 { get; protected set; }


        public string AddressLine2 { get; protected set; }
        public Guid CountryId { get; protected set; }
    }
}
