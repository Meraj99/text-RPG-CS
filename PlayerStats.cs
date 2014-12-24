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
        public int HelmetBoost { get; set; }
        public int ChestplateBoost { get; set; }
        public int LeggingsBoost { get; set; }
        public int FootwearBoost { get; set; }

        public int ArmorBoost
        {
            get
            {
                return HelmetBoost + ChestplateBoost + LeggingsBoost + FootwearBoost;
            }
        }
    }
}
