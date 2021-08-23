using System;
using System.Collections.Generic;

namespace DoctorWho.Db.Domain
{
    public class Enemy
    {
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string Description { get; set; }
        public ICollection<Episode> Episodes { get; set; }

        public Enemy()
        {
            Episodes = new List<Episode>();
        }
    }
}