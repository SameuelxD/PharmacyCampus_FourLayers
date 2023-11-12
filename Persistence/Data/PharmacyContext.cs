using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext(DbContextOptions options) : base(options) { }
        public DbSet<AddressPerson> AddressPeople { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ContactPerson> ContactPeople { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryManagement> InventoryManagements { get; set; }
        public DbSet<MovementDetail> MovementDetails { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<PurchaseMethod> PurchaseMethods { get; set; }
        public DbSet<PersonRole> PeopleRoles { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<MovementType> MovementsTypes { get; set; }
        public DbSet<PersonType> PeopleTypes { get; set; }
        public DbSet<PresentationType> PresentationTypes { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UserRols { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}