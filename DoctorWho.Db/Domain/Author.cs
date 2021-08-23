using System;
using System.Collections.Generic;

namespace DoctorWho.Db.Domain
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public ICollection<Episode> Episodes { get; set; }

        public Author()
        {
            Episodes = new List<Episode>();
        }
    }
}