using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace textBasedRPG_CS
{
    class Program
    {
        static string input { get; set; }



        static bool callBattleAgain { get; set; }

        static int userHP { get; set; }
        static int enemyHP { get; set; }
        static string battleChoice { get; set; }
        static string adminPasswordInput { get; set; }




        static void Main(string[] args)
        {
            PlayerStats player = new PlayerStats();
            BinaryFormatter formatter = new BinaryFormatter();

inputFail:
            Console.WriteLine("Type play. Or, type load to load stats." + Environment.NewLine);
            Console.WriteLine("Save file exists: " + File.Exists("playerStats.dat"));
            input = Console.ReadLine();
            Console.Clear();

            switch (input.ToLower())
            {


                case "adminaccess":
                    Console.WriteLine("Enter password to access admin controls.");
                    adminPasswordInput = Console.ReadLine();
                    if (adminPasswordInput == "admin123") //If admin password input is correct,
                    {
                        Console.WriteLine("Password accepted.");
                        Console.ReadLine();
                        Console.Clear();
                        player.AdminAccess = true; //Turns admin controls on
                        goto playStart;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password.");
                        Console.ReadLine();
                        Console.Clear();
                        goto inputFail;
                    }
                case "load":
                    if (File.Exists("playerStats.dat")) //If save file exists,
                    {
                        using (Stream inputDeserialize = File.OpenRead("playerStats.dat")) //Deserialize save file
                        {
                            player = (PlayerStats)formatter.Deserialize(inputDeserialize);
                        }
                        switch (player.GameProgress)
                        {
                            case "tutorialComplete":
                                goto tutorialComplete;
                            case "bronzeArmor":
                                goto bronzeArmor;
                            default:
                                goto playStart;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Save file not found.");
                        Console.ReadLine();
                        Console.Clear();
                        goto inputFail;
                    }
                case "play":
                    //Main game code goes here
            playStart:
                    using(Stream output = File.Create("playerStats.dat")) //Serialize save file
                    {
                        formatter.Serialize(output, player);
                    }
                    Console.WriteLine("SUCCESS");
                    Console.Clear();

                    Console.WriteLine("Welcome to the game. This is a text-based RPG made by Meraj Ahmed in C#. Press  enter to continue, and begin the tutorial.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("This tutorial will guide you through the basics of the game. Have fun!");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Through most of the game, you will have 3 battle choices: Hit, Bash, and Heal." + Environment.NewLine);
                    Console.WriteLine("Hit is a normal attack.");
                    Console.WriteLine("Bash is an attack that deals extra damage to the enemy, as well as extra damage to yourself.");
                    Console.WriteLine("Heal simply heals you for an amount of your HP." + Environment.NewLine);
                    Console.WriteLine("You will be presented with more choices later on, and they will be introduced   when you learn them.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("You encounter a monster with 10 HP. It looks fierce, but you think you can take it on. Your HP: 20.");
                    Console.ReadLine();
                    Console.Clear();

                    do
                    {
                        callBattleAgain = Battle(15, 20, player.swordDamage, 5, 3.33, player);
                    } while (callBattleAgain);
                    Console.Clear();

                    Console.WriteLine("Congratulations! You have successfully defeated the monster.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("You have looted and equipped Starter Sword.");
                    Console.WriteLine("Swords, armor, and equipment give you boosts to your stats. The Starter Sword   you have just recieved gives you a x1.2 damage multiplier.");
                    Console.ReadLine();
                    Console.Clear();

                    player.DamageMultiplier = 1.2F; //Starter Sword equipped

                    Console.WriteLine("Congratulations! You have successfully completed the tutorial." + Environment.NewLine);
                    Console.WriteLine("You are now ready to play the game. You will encounter RPG elements, and new    features will be introduced as you progress.");
                    Console.ReadLine();
                    Console.Clear();

                    player.GameProgress = "tutorialComplete"; //Tutorial complete

                    using (Stream output = File.Create("playerStats.dat")) //Serialize save file
                    {
                        formatter.Serialize(output, player);
                    }

            tutorialComplete:

                    Console.WriteLine("You are awoken from your sleep by a knock at the door.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("You open it, to find the king's guards waiting for you. You find that the king  has summoned you.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("The king has heard of your previous conquests in the land of Skyrim. He has a   task waiting for you.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("He informs you, of a Dark Troll in the Maiden Fields, that has been haunting thepeople of the village nearby.");
                    Console.WriteLine("He offers you the task of killing the troll, and says that he will reward you.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("You readily accept the task, and head out to the Maiden Fields, to slay the     Troll, and to gain recognition amongst the king, and the people of Skyrim.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("You find a small cave, and head in to search for the troll." + Environment.NewLine);
                    Console.WriteLine("You find the troll waiting for you. He lunges to swipe at you with his claws,   but you quickly dodge.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Dark Troll HP: 15.");
                    Console.WriteLine("Your HP: 20.");
                    Console.ReadLine();
                    Console.Clear();

                    do
                    {
                        callBattleAgain = Battle(15, 20, player.swordDamage, 5, 3.33, player);
                    } while (callBattleAgain);
                    Console.Clear();

                    Console.WriteLine("The troll falls to the ground, and you find a shimmering fire essence by him.");
                    Console.WriteLine("You return to the king." + Environment.NewLine);
                    Console.WriteLine("You have learnt the Fireball skill.");
                    Console.ReadLine();
                    Console.Clear();

                    player.FireballLearnt = true; //Fireball skill learnt

                    Console.WriteLine("The king rewards you greatly with a set of Bronze Armor." + Environment.NewLine);
                    Console.WriteLine("Bronze Helmet: +2HP");
                    Console.WriteLine("Bronze Chestplate: +4HP");
                    Console.WriteLine("Bronze Leggings: +2HP");
                    Console.WriteLine("Bronze Footwear: +2HP");
                    Console.ReadLine();
                    Console.Clear();

                    player.HelmetBoost = 2; //Bronze Helmet equipped
                    player.ChestplateBoost = 4; //Bronze Chestplate equipped
                    player.LeggingsBoost = 2; //Bronze Leggings equipped
                    player.FootwearBoost = 2; //Bronze Footwear equipped

                    player.GameProgress = "bronzeArmor"; //Bronze armor acquired

                    using (Stream output = File.Create("playerStats.dat")) //Serialize save file
                    {
                        formatter.Serialize(output, player);
                    }

                bronzeArmor:

                    Console.WriteLine("He then warns you of a dragon, Alduin, that has been terrorizing the citizens ofSkyrim.");
                    Console.WriteLine("He warns you, that Alduin will not be easy to defeat, and you will need lots of preparation and training.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("You decide to head out to the town to look for small jobs, to train. As you exitthe king's palace, a man asks you for some help, with recovering an ancient     artifact.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("You agree, and he tells you that it can be found in a mineshaft near the        outskirts of the town.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("You head out, and enter the shaft to find a Skeletal Warrior there.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Skeletal Warrior HP: 25.");
                    Console.WriteLine("Your HP: " + (20 + player.ArmorBoost) + ".");
                    Console.ReadLine();
                    Console.Clear();

                    do
                    {
                        callBattleAgain = Battle(25, 20 + player.ArmorBoost, player.swordDamage, 5, 3.33, player);
                    } while (callBattleAgain);
                    Console.Clear();

                    Console.WriteLine("You defeat the warrior, and find yourself being hit by another warrior from the back. You fall down, and are weakened.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Skeletal Warrior HP: 25.");
                    Console.WriteLine("Your HP: " + ((20 + player.ArmorBoost) * 0.66 + "."));
                    Console.ReadLine();
                    Console.Clear();

                    do
                    {
                        callBattleAgain = Battle(25, (int)((20 + player.ArmorBoost) * 0.66), player.swordDamage, 5, 3.33, player);
                    } while (callBattleAgain);
                    Console.Clear();

                    Console.WriteLine("The warrior drops a bronze sword. You pick it up." + Environment.NewLine);
                    Console.WriteLine("The bronze sword gives you 8 damage, and a x1.2 damage multiplier.");
                    Console.ReadLine();
                    Console.Clear();

                    player.swordDamage = 8; //Bronze sword equipped
                    player.DamageMultiplier = 1.2F; //Bronze sword equipped

                    Console.WriteLine("You find the artifact the man was looking for on the ground. You pick it up, and head back to the man.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("As you leave the shaft, you find a lightning relic by the exit." + Environment.NewLine);
                    Console.WriteLine("You have learnt the Lightning skill.");
                    Console.ReadLine();
                    Console.Clear();



                    Console.WriteLine("WORK IN PROGRESS. WORK IN PROGRESS. WORK IN PROGRESS.");
                    Console.ReadLine();
                    Console.Clear();


                    //WORK IN PRORGRESS. WORK IN PROGRESS. WORK IN PROGRESS.



                    break;
                    //Main game code ends here

                default:
                    Console.WriteLine("Sorry, invalid input.");
                    Console.ReadLine();
                    Console.Clear();
                    goto inputFail;
            }
            Console.ReadLine();
        }




        public static bool Battle(int enemyHP, int userHP, int damageToEnemy, int damageToUser, double healLevel, PlayerStats player)
        {
            
            int enemyHPforRetry = enemyHP;
            int userHPforRetry = userHP;
            while (enemyHP > 0)
            {
            battleChoiceFail:
                Console.Clear();
                Console.WriteLine("Enemy HP: " + enemyHP);
                Console.WriteLine("User HP: " + userHP + Environment.NewLine);
                Console.WriteLine("Do you want to hit the enemy, bash, or heal?");
                battleChoice = Console.ReadLine();

                switch (battleChoice.ToLower())
                {
                    case "hit":
                        battle.Hit(damageToEnemy, damageToUser, player.DamageMultiplier);
                        break;
                    case "bash":
                        battle.Bash(damageToEnemy, damageToUser, player.DamageMultiplier);
                        break;
                    case "heal":
                        battle.Heal(damageToUser, healLevel);
                        userHP += battle.HealAmount;
                        break;
                    case "fireball":
                        if (player.FireballLearnt)
                        {
                            battle.Fireball(damageToUser, player.FireballLevel);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You have not learnt the fireball skill yet.");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case "adminhit":
                        battle.AdminHit(player);
                        break;
                    default:
                        goto battleChoiceFail;
                }
                enemyHP -= battle.DamageDoneToEnemy;
                userHP -= battle.DamageDoneToUser;
                battle.DamageDoneToEnemy = 0;
                battle.DamageDoneToUser = 0;
                if (userHP <= 0)
                {
                    Console.WriteLine("You have died. Press enter to retry.");
                    Console.ReadLine();
                    Console.Clear();

                    return true;
                }
            }
            return false;
        }




    }
}
