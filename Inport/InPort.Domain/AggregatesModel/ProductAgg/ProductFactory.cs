namespace InPort.Domain.AggregatesModel.ProductAgg
{
    public static class ProductFactory
    {
        public static Product CreateProduct(string name, string description)
        {
            //crear nueva instancia y establecer identidad
            var product = new Product(name, description);

            product.GenerateNewIdentity();


            return product;
        }
    }
}
