using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Data;

namespace Application.Repositories
{
    public class ContactPersonRepository : GenericRepository<ContactPerson>, IContactPersonRepository
    {
        private readonly PharmacyContext _context;

        public ContactPersonRepository(PharmacyContext context) : base(context)
        {
            _context = context;
        }
    }
}