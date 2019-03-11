namespace InPort.Domain.AggregatesModel.MeasurentUnitAgg
{
    public static class MeasurentUnitFactory
    {
        public static MeasurentUnit CreateMeasurentUnit(MeasurentUnitType measurentUnitType, string name)
        {
            //crear nueva instancia y establecer identidad
            var measurentUnit = new MeasurentUnit(measurentUnitType, name);

            measurentUnit.GenerateNewIdentity();

            return measurentUnit;
        }
    }
}
