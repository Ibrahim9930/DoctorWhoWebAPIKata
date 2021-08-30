using System.Collections.Generic;
using System.Linq;
using DoctorWho.Db.Domain;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class EnemyEFRepository : EFRepository<Enemy>
    {
        public EnemyEFRepository(DoctorWhoCoreDbContext context) : base(context)
        {
        }

        public override Enemy GetByIdWithRelatedData(int id)
        {
            return _context.Enemies
                .Include(en => en.Episodes)
                .First(en => en.EnemyId == id);
        }

        public override IEnumerable<Enemy> GetAllEntitiesWithRelatedData()
        {
            return _context.Enemies
                .Include(en => en.Episodes);
        }
    }
}