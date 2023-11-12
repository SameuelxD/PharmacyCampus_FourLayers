using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class MovementTypeRepository : GenericRepository<MovementType>, IMovementTypeRepository
    {
        private readonly PharmacyContext _context;

        public MovementTypeRepository(PharmacyContext context) : base(context)
        {
            _context = context;
        }
    }
}