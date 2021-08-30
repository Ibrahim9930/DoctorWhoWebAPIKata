using System;
using System.Collections.Generic;

namespace DoctorWho.Db.Domain
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public int DoctorNumber { get; set; }
        public string DoctorName { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }
        public ICollection<Episode> Episodes { get; set; }

        public Doctor()
        {
            Episodes = new List<Episode>();
        }
    }
}