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
        public DbSet<PersonRole> PeopleRole { get; set; }
        public DbSet<ContactType> ContactsType { get; set; }
        public DbSet<DocumentType> DocumentsType { get; set; }
        public DbSet<MovementType> MovementTypes { get; set; }
        public DbSet<PersonType> PeopleType { get; set; }
        public DbSet<PresentationType> PresentationTypes { get; set; }
        

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}