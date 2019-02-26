using AutoMapper;
using InPort.Application.Core.Interfaces.Mapping;
using InPort.Domain.AggregatesModel.CustomerAgg;

namespace InPort.Application.Customers.Queries.GetCustomersList
{
    public class CustomerLookupModel : IHaveCustomMapping
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Customer, CustomerLookupModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(cDTO => cDTO.Name, opt => opt.MapFrom(c => c.FullName));
        }
    }
}
