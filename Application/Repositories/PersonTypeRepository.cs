using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class PersonTypeRepository : GenericRepository<PersonType>, IPersonTypeRepository
    {
        private readonly PharmacyContext _context;

        public PersonTypeRepository(PharmacyContext context) : base(context)
        {
            _context = context;
        }
    }
}