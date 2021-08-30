using System.Collections.Generic;
using System.Linq;
using DoctorWho.Db.Domain;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class AuthorEFRepository : EFRepository<Author>
    {
        public AuthorEFRepository(DoctorWhoCoreDbContext context) : base(context)
        {
        }

        public override Author GetByIdWithRelatedData(int id)
        {
            return _context.Authors
                .Include(a => a.Episodes)
                .First(a => a.AuthorId == id);
        }

        public override IEnumerable<Author> GetAllEntitiesWithRelatedData()
        {
            return _context.Authors
                .Include(a => a.Episodes);
        }
    }
}