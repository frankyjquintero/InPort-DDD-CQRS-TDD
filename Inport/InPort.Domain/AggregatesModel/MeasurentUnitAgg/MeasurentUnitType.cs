using System;
using System.Collections.Generic;
using System.Linq;
using InPort.Domain.Core;

namespace InPort.Domain.AggregatesModel.MeasurentUnitAgg
{
    public class MeasurentUnitType : Enumeration
    {
        public static readonly MeasurentUnitType Longitud = new MeasurentUnitType(1, nameof(Longitud).ToLowerInvariant());
        public static readonly MeasurentUnitType Masa = new MeasurentUnitType(2, nameof(Masa).ToLowerInvariant());
        public static readonly MeasurentUnitType Volumen = new MeasurentUnitType(3, nameof(Volumen).ToLowerInvariant());
        public static readonly MeasurentUnitType Personalizada = new MeasurentUnitType(4, nameof(Personalizada).ToLowerInvariant());

        protected MeasurentUnitType()
        {
        }

        public MeasurentUnitType(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<MeasurentUnitType> List() =>
            new[] { Longitud, Masa, Volumen, Personalizada };

        public static MeasurentUnitType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new Exception($"Possible values for MeasurentUnitType: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static MeasurentUnitType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new Exception($"Possible values for MeasurentUnitType: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
