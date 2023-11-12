using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {

        IAddressPersonRepository AddressPeople { get; }
        IBillRepository Bills { get; }
        ICityRepository Cities { get; }
        IContactPersonRepository ContactPeople { get; }
        IContactTypeRepository ContactTypes { get; }
        ICountryRepository Countries { get; }
        IDepartmentRepository Departments { get; }
        IDocumentTypeRepository DocumentTypes { get; }
        IInventoryRepository Inventories { get; }
        IInventoryManagementRepository InventoryManagements { get; }
        IMovementDetailRepository MovementDetails { get; }
        IPersonRepository People { get; }
        IProductRepository Products { get; }
        IProductBrandRepository ProductBrands { get; }
        IPurchaseMethodRepository PurchaseMethods { get; }
        IPersonRoleRepository PeopleRoles { get; }
        IMovementTypeRepository MovementsTypes { get; }
        IPresentationTypeRepository PresentationTypes { get; }
        IPersonTypeRepository PeopleTypes { get; }
        IRefreshTokenRepository RefreshTokens { get; }
        IRolRepository Rols { get; }
        IUserRepository Users { get; }
        Task<int> SaveAsync();
    }
}