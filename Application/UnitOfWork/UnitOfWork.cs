using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PharmacyContext _context;
        private AddressPersonRepository _addressPeople;
        private BillRepository _bills;
        private CityRepository _cities;
        private ContactPersonRepository _contactPeople;
        private ContactTypeRepository _contactTypes;
        private CountryRepository _countries;
        private DepartmentRepository _departments;
        private DocumentTypeRepository _documentTypes;
        private InventoryRepository _inventories;
        private InventoryMagementRepository _inventoryManagements;
        private MovementDetailRepository _movementDetails;
        private PersonRepository _people;
        private ProductRepository _products;
        private ProductBrandRepository _productBrands;
        private PurchaseMethodRepository _purchaseMethods;
        private PersonRoleRepository _peopleRoles;
        private PersonTypeRepository _peopleTypes;
        private PresentationTypeRepository _presentationTypes;
        private MovementTypeRepository _movementsTypes;

        private IRolRepository _rols;
        private IUserRepository _users;
        private IRefreshTokenRepository _refreshTokens;
        //*-----*//
        public UnitOfWork(PharmacyContext context)
        {
            _context=context;
        }
        //*-----*//

        public IRefreshTokenRepository RefreshTokens
        {
            get
            {
                if (_refreshTokens == null)
                {
                    _refreshTokens = new RefreshTokenRepository(_context);
                }
                return _refreshTokens;
            }
        }
        public IRolRepository Rols
        {
            get
            {
                if (_rols == null)
                {
                    _rols = new RolRepository(_context);
                }
                return _rols;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }

        public IAddressPersonRepository AddressPeople
        {
            get
            {
                if (_addressPeople == null)
                {
                    _addressPeople = new AddressPersonRepository(_context);
                }
                return _addressPeople;
            }
        }

        public IBillRepository Bills
        {
            get
            {
                if (_bills == null)
                {
                    _bills = new BillRepository(_context);
                }
                return _bills;
            }
        }

        public ICityRepository Cities
        {
            get
            {
                if (_cities == null)
                {
                    _cities = new CityRepository(_context);
                }
                return _cities;
            }
        }

        public IContactPersonRepository ContactPeople
        {
            get
            {
                if (_contactPeople == null)
                {
                    _contactPeople = new ContactPersonRepository(_context);
                }
                return _contactPeople;
            }
        }

        public IContactTypeRepository ContactTypes
        {
            get
            {
                if (_contactTypes == null)
                {
                    _contactTypes = new ContactTypeRepository(_context);
                }
                return _contactTypes;
            }
        }

        public ICountryRepository Countries
        {
            get
            {
                if (_countries == null)
                {
                    _countries = new CountryRepository(_context);
                }
                return _countries;
            }
        }

        public IDepartmentRepository Departments
        {
            get
            {
                if (_departments == null)
                {
                    _departments = new DepartmentRepository(_context);
                }
                return _departments;
            }
        }

        public IDocumentTypeRepository DocumentTypes
        {
            get
            {
                if (_documentTypes == null)
                {
                    _documentTypes = new DocumentTypeRepository(_context);
                }
                return _documentTypes;
            }
        }

        public IInventoryRepository Inventories
        {
            get
            {
                if (_inventories == null)
                {
                    _inventories = new InventoryRepository(_context);
                }
                return _inventories;
            }
        }

        public IInventoryManagementRepository InventoryManagements
        {
            get
            {
                if (_inventoryManagements == null)
                {
                    _inventoryManagements = new InventoryMagementRepository(_context);
                }
                return _inventoryManagements;
            }
        }

        public IMovementDetailRepository MovementDetails
        {
            get
            {
                if (_movementDetails == null)
                {
                    _movementDetails = new MovementDetailRepository(_context);
                }
                return _movementDetails;
            }
        }

        public IPersonRepository People
        {
            get
            {
                if (_people == null)
                {
                    _people = new PersonRepository(_context);
                }
                return _people;
            }
        }

        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductRepository(_context);
                }
                return _products;
            }
        }

        public IProductBrandRepository ProductBrands
        {
            get
            {
                if (_productBrands == null)
                {
                    _productBrands = new ProductBrandRepository(_context);
                }
                return _productBrands;
            }
        }

        public IPurchaseMethodRepository PurchaseMethods
        {
            get
            {
                if (_purchaseMethods == null)
                {
                    _purchaseMethods = new PurchaseMethodRepository(_context);
                }
                return _purchaseMethods;
            }
        }

        public IPersonRoleRepository PeopleRoles
        {
            get
            {
                if (_peopleRoles == null)
                {
                    _peopleRoles = new PersonRoleRepository(_context);
                }
                return _peopleRoles;
            }
        }

        public IMovementTypeRepository MovementsTypes
        {
            get
            {
                if (_movementsTypes == null)
                {
                    _movementsTypes = new MovementTypeRepository(_context);
                }
                return _movementsTypes;
            }
        }

        public IPresentationTypeRepository PresentationTypes
        {
            get
            {
                if (_presentationTypes == null)
                {
                    _presentationTypes = new PresentationTypeRepository(_context);
                }
                return _presentationTypes;
            }
        }

        public IPersonTypeRepository PeopleTypes
        {
            get
            {
                if (_peopleTypes == null)
                {
                    _peopleTypes = new PersonTypeRepository(_context);
                }
                return _peopleTypes;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }


}