using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class PersonRoleRepository : GenericRepository<PersonRole>, IPersonRoleRepository
    {
        private readonly PharmacyContext _context;

        public PersonRoleRepository(PharmacyContext context) : base(context)
        {
            _context = context;
        }
    }
}