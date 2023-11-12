using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
        {
            public MappingProfiles()
            {
                CreateMap<AddressPerson,AddressPersonDto>()
                .ReverseMap();
                
                CreateMap<Bill,BillDto>()
                .ReverseMap();
                
                CreateMap<City,CityDto>()
                .ReverseMap()
                .ForMember(o => o.AddressesPeople ,d => d.Ignore());
                
                CreateMap<ContactPerson,ContactPersonDto>().ReverseMap();
                
                CreateMap<ContactType,ContactTypeDto>()
                .ReverseMap()
                .ForMember(o => o.ContactPeople ,d => d.Ignore());

                CreateMap<Country,CountryDto>()
                .ReverseMap()
                .ForMember(o => o.Departments ,d => d.Ignore());

                CreateMap<Department,DepartmentDto>()
                .ReverseMap()
                .ForMember(o => o.Cities ,d => d.Ignore());

                CreateMap<DocumentType,DocumentTypeDto>()
                .ReverseMap()
                .ForMember(o => o.People ,d => d.Ignore());

                CreateMap<Inventory,InventoryDto>()
                .ReverseMap()
                .ForMember(o => o.MovementsDetails ,d => d.Ignore());

                CreateMap<InventoryManagement,InventoryManagementDto>().ReverseMap()
                .ForMember(o => o.MovementsDetails ,d => d.Ignore());

                CreateMap<MovementDetail,MovementDetailDto>()
                .ReverseMap();
                
                CreateMap<MovementType,MovementTypeDto>()
                .ReverseMap()
                .ForMember(o => o.InventoriesManagement ,d => d.Ignore());

                CreateMap<Person,PersonDto>()
                .ReverseMap()
                .ForMember(o => o.AddressPeople ,d => d.Ignore())
                .ForMember(o => o.ContactPeople ,d => d.Ignore())
                .ForMember(o => o.InventoriesManagement ,d => d.Ignore());

                CreateMap<PersonRole,PersonRoleDto>()
                .ReverseMap()
                .ForMember(o => o.People ,d => d.Ignore());

                CreateMap<PersonType,PersonTypeDto>()
                .ReverseMap()
                .ForMember(o => o.People ,d => d.Ignore());

                CreateMap<PresentationType,PresentationTypeDto>()
                .ReverseMap()
                .ForMember(o => o.Inventories ,d => d.Ignore());
                
                CreateMap<Product,ProductDto>()
                .ReverseMap()
                .ForMember(o => o.Inventories,d=>d.Ignore());


                CreateMap<ProductBrand,ProductBrandDto>()
                .ReverseMap()
                .ForMember(o => o.Products ,d => d.Ignore());
                
                CreateMap<PurchaseMethod,PurchaseMethodDto>()
                .ReverseMap()
                .ForMember(o => o.InventoriesManagement ,d => d.Ignore());
                
                
            }
        }
}