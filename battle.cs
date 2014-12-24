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
        public static int DamageDoneToEnemy;
        public static int DamageDoneToUser;
        public static int HealAmount;


        public static void Hit(int damageToEnemy, int damageToUser, float damageMultiplier)
        {
            DamageDoneToEnemy = (int)(randomGen.Next(damageToEnemy) * damageMultiplier);
            DamageDoneToUser = randomGen.Next(damageToUser);
        }

        public static void Bash(int damageToEnemy, int damageToUser, float damageMultiplier)
        {
            DamageDoneToEnemy = (int)(randomGen.Next(damageToEnemy) + (20 / 100 * (randomGen.Next(damageToEnemy))) * damageMultiplier);
            DamageDoneToUser = randomGen.Next(damageToUser) + (15 / 100 * (randomGen.Next(damageToUser)));
        }

        public static void Heal(int damageToUser, double healLevel)
        {
            DamageDoneToEnemy = 0;
            DamageDoneToUser = randomGen.Next(damageToUser);
            HealAmount = (int)(healLevel * 9.0/10.0);
        }


        public static void Fireball(int damagetoUser)
        {
            DamageDoneToEnemy = 40 + (10 * Program.FireballLevel);
            DamageDoneToUser = randomGen.Next(damagetoUser);
        }

        
        public static void AdminHit(PlayerStats player)
        {
            if (player.AdminAccess)
            {
                Program.EnemyHP = 0;
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
