
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly PharmacyContext _context;

        public CountryRepository(PharmacyContext context) : base(context)
        {
            _context = context;
        }
    }
}