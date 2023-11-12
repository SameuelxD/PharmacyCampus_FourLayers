using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class PresentationTypeRepository : GenericRepository<PresentationType>, IPresentationTypeRepository
    {
        private readonly PharmacyContext _context;

        public PresentationTypeRepository(PharmacyContext context) : base(context)
        {
            _context = context;
        }
    }
}