using System;
using System.Collections.Generic;

namespace DoctorWho.Db.Domain
{
    public class Episode
    {
        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateTime? EpisodeDate { get; set; }
        public string Notes { get; set; }

        public ICollection<Enemy> Enemies { get; set; }
        public ICollection<Companion> Companions { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public Episode()
        {
            Enemies = new List<Enemy>();
            Companions = new List<Companion>();
        }
    }
}