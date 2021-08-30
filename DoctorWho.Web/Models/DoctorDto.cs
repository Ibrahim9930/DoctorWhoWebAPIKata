using System;
using System.Collections.Generic;
using DoctorWho.Db.Domain;

namespace DoctorWho.Web.Models
{
    public class DoctorDto
    {
        public int DoctorNumber { get; set; }
        public string DoctorName { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }
    }
}