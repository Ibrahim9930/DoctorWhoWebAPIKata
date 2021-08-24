using System;

namespace DoctorWho.Web.Models
{
    public class DoctorForCreationWithPostDto : DoctorForManipulationDto
    {
        public int DoctorNumber { get; set; }

    }
}