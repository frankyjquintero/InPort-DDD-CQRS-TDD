using System;

namespace InPort.Infra.Core
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
