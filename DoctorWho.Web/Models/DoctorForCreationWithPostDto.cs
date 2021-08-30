using System;

namespace DoctorWho.Web.Models
{
    public class DoctorForCreationWithPostDto
    {
        public int DoctorNumber { get; set; }
        public string DoctorName { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }
    }
}