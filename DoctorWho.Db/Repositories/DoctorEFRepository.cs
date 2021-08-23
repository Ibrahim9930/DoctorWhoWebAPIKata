using System.Collections.Generic;
using System.Linq;
using DoctorWho.Db.Domain;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class DoctorEFRepository : EFRepository<Doctor>
    {
        public DoctorEFRepository(DoctorWhoCoreDbContext context) : base(context)
        {
        }
        
        public override Doctor GetByIdWithRelatedData(int id)
        {
            return _context.Doctors
                .Include(d=> d.Episodes)
                .First(d => d.DoctorId == id);
        }

        public override IEnumerable<Doctor> GetAllEntitiesWithRelatedData()
        {
            return _context.Doctors
                .Include(d => d.Episodes);
        }
    }
}