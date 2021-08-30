using System.Collections.Generic;
using System.Linq;
using DoctorWho.Db.Domain;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class CompanionEFRepository : EFRepository<Companion>
    {
        public CompanionEFRepository(DoctorWhoCoreDbContext context) : base(context)
        {
        }

        public override Companion GetByIdWithRelatedData(int id)
        {
            return _context.Companions
                .Include(c => c.Episodes)
                .First(c => c.CompanionId == id);
        }

        public override IEnumerable<Companion> GetAllEntitiesWithRelatedData()
        {
            return _context.Companions
                .Include(c => c.Episodes);
        }
    }
}