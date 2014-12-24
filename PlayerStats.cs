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
            swordDamage = 5;
        }
        public bool AdminAccess { get; set; }
        public float DamageMultiplier { get; set; }
        public string GameProgress { get; set; }
        public int HelmetBoost { get; set; }
        public int ChestplateBoost { get; set; }
        public int LeggingsBoost { get; set; }
        public int FootwearBoost { get; set; }
        public int swordDamage { get; set; }



        public bool FireballLearnt { get; set; }
        public int FireballLevel { get; set; }
        public bool LightningLearnt { get; set; }
        public int LightningLevel { get; set; }




        public int ArmorBoost
        {
            get
            {
                return HelmetBoost + ChestplateBoost + LeggingsBoost + FootwearBoost;
            }
        }
    }
}
