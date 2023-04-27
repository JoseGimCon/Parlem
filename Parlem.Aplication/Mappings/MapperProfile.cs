using AutoMapper;
using Parlem.Aplication.Dtos;
using Parlem.Aplication.Features.Customer.Commands.CreateCustomerCommand;
using Parlem.Aplication.Features.Customer.Commands.UpdateCustomerCommand;
using Parlem.Aplication.Features.Customer.Queries.GetAllCustomers;
using Parlem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Aplication.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            AllowNullCollections = true;
            CreateMap<CreateCustomerCommand, Customer>();

            CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CustomersDtos, opt => opt.MapFrom(src => src.Customers));


            CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.ProductsDtos, opt => opt.MapFrom(src => src.Products));


            CreateMap<GetAllCustomersQuery, GetAllClientesFilter>();
        }
    }
}
