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
                CreateMap<AddressPerson,AddressPersonDto>().ReverseMap();
                CreateMap<Bill,BillDto>().ReverseMap();
                CreateMap<City,CityDto>().ReverseMap();
                CreateMap<ContactPerson,ContactPersonDto>().ReverseMap();
                CreateMap<ContactType,ContactTypeDto>().ReverseMap();
                CreateMap<Country,CountryDto>().ReverseMap();
                CreateMap<Department,DepartmentDto>().ReverseMap();
                CreateMap<DocumentType,DocumentTypeDto>().ReverseMap();
                CreateMap<Inventory,InventoryDto>().ReverseMap();
                CreateMap<InventoryManagement,InventoryManagementDto>().ReverseMap();
                CreateMap<MovementDetail,MovementDetailDto>().ReverseMap();
                CreateMap<MovementType,MovementTypeDto>().ReverseMap();
                CreateMap<Person,PersonDto>().ReverseMap();
                CreateMap<PersonRole,PersonRoleDto>().ReverseMap();
                CreateMap<PersonType,PersonTypeDto>().ReverseMap();
                CreateMap<PresentationType,PresentationTypeDto>().ReverseMap();
                CreateMap<ProductBrand,ProductBrandDto>().ReverseMap();
                CreateMap<Product,ProductDto>().ReverseMap();
                CreateMap<PurchaseMethod,PurchaseMethodDto>().ReverseMap();
                
                
            }
        }
}