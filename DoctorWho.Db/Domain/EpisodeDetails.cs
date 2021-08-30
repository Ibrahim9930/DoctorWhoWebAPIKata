using System;
using System.Collections.Generic;

namespace DoctorWho.Db.Domain
{
    public class EpisodeDetails
    {
        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateTime? EpisodeDate { get; set; }
        public string Notes { get; set; }

        public string AuthorName { get; set; }
        public string DoctorName { get; set; }
        public string CompanionsNames { get; set; }
        public string EnemiesNames { get; set; }
    }
}