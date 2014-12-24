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
        static string input = "";


        public static int HelmetBoost;
        public static int ChestplateBoost;
        public static int LeggingsBoost;
        public static int FootwearBoost;
        public static int ArmorBoost
        {
            get
            {
                return HelmetBoost + ChestplateBoost + LeggingsBoost + FootwearBoost;
            }
        }


        public static int UserHP;
        public static int EnemyHP;
        public static int HealAmount;
        static string battleChoice;
        static string adminPasswordInput;

        public static bool FireballLearnt;
        public static int FireballLevel = 0;

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
                    if (adminPasswordInput == "admin123") //Checks if admin password input is correct
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

            userDead1: //Battle 1 START
                    Console.WriteLine("You encounter a monster with 10 HP. It looks fierce, but you think you can take it on. Your HP: 15.");
                    Console.ReadLine();
                    Console.Clear();

                    EnemyHP = 10;
                    UserHP = 15;
                    while (EnemyHP > 0)
                    {   
                    battleChoiceFail1:
                        Console.Clear();
                        Console.WriteLine("Enemy HP: " + EnemyHP);
                        Console.WriteLine("User HP: " + UserHP + Environment.NewLine);
                        Console.WriteLine("Do you want to hit the enemy, bash, or heal?");
                        battleChoice = Console.ReadLine();

                        switch (battleChoice.ToLower())
                        {
                            case "hit":
                                battle.Hit(5, 5, player.DamageMultiplier);
                                break;
                            case "bash":
                                battle.Bash(5, 5, player.DamageMultiplier);
                                break;
                            case "heal":
                                battle.Heal(5, 3.33);
                                UserHP += battle.HealAmount;
                                break;
                            case "fireball":

                            case "adminhit":
                                battle.AdminHit(player);
                                break;
                            default:
                                goto battleChoiceFail1;
                        }
                        EnemyHP -= battle.DamageDoneToEnemy;
                        UserHP -= battle.DamageDoneToUser;
                        battle.DamageDoneToEnemy = 0;
                        battle.DamageDoneToUser = 0;
                        if (UserHP <= 0)
                        {
                            Console.WriteLine("You have died. Press enter to retry.");
                            Console.ReadLine();
                            Console.Clear();

                            goto userDead1;
                        }
                    } //Battle 1 END

                    Console.WriteLine("Congratulations! You have successfully defeated the monster.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("You have looted and equipped Starter Sword.");
                    Console.WriteLine("Swords, armor, and equipment give you boosts to your stats. The Starter Sword you have just recieved gives you a x1.2 damage multiplier.");
                    Console.ReadLine();
                    Console.Clear();

                    player.DamageMultiplier = 1.2F; //Starter Sword equipped

                    Console.WriteLine("Congratulations! You have successfully completed the tutorial." + Environment.NewLine);
                    Console.WriteLine("You are now ready to play the game. You will encounter RPG elements, and new features will be introduced as you progress.");
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

                    Console.WriteLine("You open it, to find the king's guards waiting for you. You find that the king has summoned you.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("The king has heard of your previous conquests in the land of Skyrim. He has a task waiting for you.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("He informs you, of a Dark Troll in the Maiden Fields, that has been haunting the people of the village nearby.");
                    Console.WriteLine("He offers you the task of killing the troll, and says that he will reward you.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("You readily accept the task, and head out to the Maiden Fields, to slay the Troll, and to gain recognition amongst the king, and the people of Skyrim.");
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("You find a small cave, and head in to search for the troll." + Environment.NewLine);
                    Console.WriteLine("You find the troll waiting for you. He lunges to swipe at you with his claws, but you quickly dodge.");
                    Console.ReadLine();
                    Console.Clear();

            userDead2: //Battle 2 START
                    Console.WriteLine("Dark Troll HP: 15." + Environment.NewLine);
                    Console.WriteLine("Your HP: 15.");
                    Console.ReadLine();
                    Console.Clear();

                    EnemyHP = 15;
                    UserHP = 15;
                    while (EnemyHP > 0)
                    {   
                    battleChoiceFail2:
                        Console.Clear();
                        Console.WriteLine("Enemy HP: " + EnemyHP);
                        Console.WriteLine("User HP: " + UserHP + Environment.NewLine);
                        Console.WriteLine("Do you want to hit the enemy, bash, or heal?");
                        battleChoice = Console.ReadLine();

                        switch (battleChoice.ToLower())
                        {
                            case "hit":
                                battle.Hit(5, 5, player.DamageMultiplier);
                                break;
                            case "bash":
                                battle.Bash(5, 5, player.DamageMultiplier);
                                break;
                            case "heal":
                                battle.Heal(5, 3.33);
                                UserHP += battle.HealAmount;
                                break;
                            case "adminhit":
                                battle.AdminHit(player);
                                break;
                            default:
                                goto battleChoiceFail2;
                        }
                        EnemyHP -= battle.DamageDoneToEnemy;
                        UserHP -= battle.DamageDoneToUser;
                        battle.DamageDoneToEnemy = 0;
                        battle.DamageDoneToUser = 0;
                        if (UserHP <= 0)
                        {
                            Console.WriteLine("You have died. Press enter to retry.");
                            Console.ReadLine();
                            Console.Clear();

                            goto userDead2;
                        }
                    } //Battle 2 END

                    Console.WriteLine("The troll falls to the ground, and you find a shimmering fire essence by him.");
                    Console.WriteLine("You return to the king." + Environment.NewLine);
                    Console.WriteLine("You have learnt the fireball skill.");
                    Console.ReadLine();
                    Console.Clear();

                    FireballLearnt = true; //Fireball skill learnt

                    Console.WriteLine("The king rewards you greatly with a set of Bronze Armor." + Environment.NewLine);
                    Console.WriteLine("Bronze Helmet: +2HP");
                    Console.WriteLine("Bronze Chestplate: +4HP");
                    Console.WriteLine("Bronze Leggings: +2HP");
                    Console.WriteLine("Bronze Footwear: +2HP");

                    HelmetBoost = 2; //Bronze Helmet equipped
                    ChestplateBoost = 4; //Bronze Chestplate equipped
                    LeggingsBoost = 2; //Bronze Leggings equipped
                    FootwearBoost = 2; //Bronze Footwear equipped

                    player.GameProgress = "bronzeArmor"; //Bronze armor acquired

                    using (Stream output = File.Create("playerStats.dat")) //Serialize save file
                    {
                        formatter.Serialize(output, player);
                    }

                bronzeArmor:

                    Console.WriteLine("He then warns you of a dragon, Alduin, that has been terrorizing the citizens of Skyim.");
                    Console.WriteLine("He warns you, that Alduin will not be easy to defeat, and you will need lots of preparation and training.");
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
    }
}
