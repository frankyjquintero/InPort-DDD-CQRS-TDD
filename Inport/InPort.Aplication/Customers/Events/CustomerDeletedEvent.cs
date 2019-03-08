﻿using InPort.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Aplication.Customers.Events
{
    public class CustomerDeletedEvent : Event
    {
        public Guid CustomerId { get; private set; }

        public CustomerDeletedEvent(Guid customerId) :
            base(customerId)
        {
            CustomerId = customerId;
        }
    }
}
