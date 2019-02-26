using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Infra.Core
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
