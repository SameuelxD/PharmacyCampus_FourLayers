using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        private readonly PharmacyContext _contex;
        public BillRepository(PharmacyContext context) : base(context)
        {
            _contex = context;
        }
    }
}