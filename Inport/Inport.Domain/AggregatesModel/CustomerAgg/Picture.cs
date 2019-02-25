using InPort.Domain.Core.Model;
using InPort.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Domain.AggregatesModel.CustomerAgg
{
    public class Picture
        : Entity
    {
        #region Properties

        /// <summary>
        /// Obtener el raw de la foto
        /// </summary>
        public byte[] RawPhoto { get; set; }

        #endregion
    }
}
