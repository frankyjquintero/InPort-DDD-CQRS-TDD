using System;
using System.Collections.Generic;
using System.Linq;
using InPort.Domain.Core;

namespace InPort.Domain.AggregatesModel.OrderIncomeAgg
{
    public class OrderIncomeStatus
        : Enumeration
    {
        public static readonly OrderIncomeStatus Ingreso = new OrderIncomeStatus(1, nameof(Ingreso).ToLowerInvariant());
        public static readonly OrderIncomeStatus RegistroBitacora = new OrderIncomeStatus(2, nameof(RegistroBitacora).ToLowerInvariant());
        public static readonly OrderIncomeStatus Dian = new OrderIncomeStatus(3, nameof(Dian).ToLowerInvariant());
        public static readonly OrderIncomeStatus VerificacionBitacora = new OrderIncomeStatus(4, nameof(VerificacionBitacora).ToLowerInvariant());
        public static readonly OrderIncomeStatus Completado = new OrderIncomeStatus(5, nameof(Completado).ToLowerInvariant());
        public static readonly OrderIncomeStatus Cancelado = new OrderIncomeStatus(6, nameof(Cancelado).ToLowerInvariant());

        protected OrderIncomeStatus()
        {
        }

        public OrderIncomeStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<OrderIncomeStatus> List() =>
            new[] { Ingreso, RegistroBitacora, Dian, VerificacionBitacora, Completado, Cancelado };

        public static OrderIncomeStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new Exception($"Possible values for OrderIncomeStatus: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static OrderIncomeStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new Exception($"Possible values for OrderIncomeStatus: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}