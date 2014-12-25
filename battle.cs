using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textBasedRPG_CS
{
    class battle
    {
        static Random randomGen = new Random();
        public static int DamageDoneToEnemy { get; set; }
        public static int DamageDoneToUser { get; set; }
        public static int HealAmount { get; set; }


        public static void Hit(int damageToEnemy, int damageToUser, PlayerStats player)
        {
            DamageDoneToEnemy = (int)(randomGen.Next(damageToEnemy) * player.DamageMultiplier);
            DamageDoneToUser = randomGen.Next(damageToUser);
        }

        public static void Bash(int damageToEnemy, int damageToUser, PlayerStats player)
        {
            DamageDoneToEnemy = (int)(randomGen.Next(damageToEnemy) + (20 / 100 * (randomGen.Next(damageToEnemy))) * player.DamageMultiplier);
            DamageDoneToUser = randomGen.Next(damageToUser) + (15 / 100 * (randomGen.Next(damageToUser)));
        }

        public static void Heal(int damageToUser, double healLevel)
        {
            DamageDoneToEnemy = 0;
            DamageDoneToUser = randomGen.Next(damageToUser);
            HealAmount = (int)(healLevel * 9.0/10.0);
        }


        public static void Fireball(int damagetoUser, int fireballLevel)
        {
            DamageDoneToEnemy = 40 + (10 * fireballLevel);
            DamageDoneToUser = randomGen.Next(damagetoUser);
        }

        public static int LightningRounds { get; set; }

        public static int Lightning(int lightningLevel)
        {
            if (LightningRounds > 0)
            {
                return (10 * lightningLevel);
            }
            else
            {
                return 0;
            }
        }

        
        public static void AdminHit(PlayerStats player)
        {
            if (player.AdminAccess)
            {
                DamageDoneToEnemy = 2147483647;
            }
            else
            {
                Console.WriteLine("Sorry, you don't have access to admin controls.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
