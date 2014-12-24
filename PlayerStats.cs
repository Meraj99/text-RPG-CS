using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textBasedRPG_CS
{
    [Serializable]
    class PlayerStats
    {
        public PlayerStats()
        {
            AdminAccess = false;
            DamageMultiplier = 1;
        }
        public bool AdminAccess { get; set; }
        public float DamageMultiplier { get; set; }
        public string GameProgress { get; set; }
    }
}
