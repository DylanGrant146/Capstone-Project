using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject
{
    class Program
    {
        //******************************************
        //Title: Traveling Merchant
        //Application Type: Console
        //Description: It simulates a game inventory system where you can purchase and resell items to a vendor
        //Author: Dylan Grant
        //Date Created: 12/3/2018
        //Last Modified: 12/5/2018
        //******************************************
        static void Main(string[] args)
        {
            DisplayWelcomeScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }
        static void DisplayMenu()

        {

            string menuChoice;
            bool exiting = false;

            StoreInventory potion = new StoreInventory();
            potion = InitializeStoreItemPotion();
            StoreInventory sword = new StoreInventory();
            sword = InitializeStoreItemSword();
            StoreInventory shield = new StoreInventory();
            shield = InitializeStoreItemShield();
            StoreInventory meat = new StoreInventory();
            meat = InitializeStoreItemMeat();


            List<StoreInventory> userInventory = new List<StoreInventory>();

            List<StoreInventory> storeInventory = new List<StoreInventory>();
            storeInventory.Add(potion);
            storeInventory.Add(sword);
            storeInventory.Add(shield);
            storeInventory.Add(meat);


            while (!exiting)
            {
                DisplayHeader("Main Menu");

                Console.WriteLine("\tA) Buy From Store");

                Console.WriteLine("\tB) Sell From Inventory");

                Console.WriteLine("\tC) Display Your Inventory");

                Console.WriteLine("\tE) Exit");


                Console.Write("Enter Choice:");

                menuChoice = Console.ReadLine();


                switch (menuChoice)
                {
                    case "A":

                    case "a":
                        DisplayStoreInventory(storeInventory, userInventory);
                        break;

                    case "B":

                    case "b":
                        DisplaySellInventory(storeInventory, userInventory);
                        break;

                    case "C":
                        
                    case "c":
                        DisplayUserInventory(storeInventory, userInventory);
                        break;  

                    case "E":

                    case "e":

                        exiting = true;

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Please choose a valid menu option.");
                        DisplayContinuePrompt();
                        break;
                }
            }
        }
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("\t\tWelcome to my shop, traveler!");
            DisplayContinuePrompt();
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void DisplayHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(headerText);
            Console.WriteLine();
        }

        static void DisplayClosingScreen()
        {
            Console.Clear();
            DisplayHeader("\t\tExiting Screen");

            Console.WriteLine("Thanks for your business!");
            DisplayContinuePrompt();
        }
        
        static void DisplayStoreInventory(List<StoreInventory> storeInventory, List<StoreInventory> userInventory)
        {
            string menuChoice;
            bool itemFound = false;

            Console.Clear();
            DisplayHeader("\tStore Inventory");

            Console.WriteLine("Item".PadRight(25) + "Value".PadLeft(10));
            Console.WriteLine("----------------------".PadRight(25) + "---------".PadLeft(10));

            foreach (StoreInventory storeItem in storeInventory)
            {
                Console.WriteLine(storeItem.ItemInfo().PadRight(25));
                Console.WriteLine(storeItem.Price.ToString("C2").PadLeft(35));
            }

            Console.WriteLine();
            Console.Write("Enter item for purchase: ");
            menuChoice = Console.ReadLine().ToUpper();

            foreach (StoreInventory storeItem in storeInventory)
            {
                if (storeItem.Name == menuChoice)
                {
                    userInventory.Add(storeItem);
                    storeInventory.Remove(storeItem);
                    Console.WriteLine("Thank you for your purchase.");
                    
                    itemFound = true;
                    break;
                }
            }
            if (!itemFound)
            {
                Console.WriteLine("I'm sorry, I don't have that for sale right now.");
            }

            DisplayContinuePrompt();
        }

        static void DisplayUserInventory(List<StoreInventory> storeInventory, List<StoreInventory> userInventory)
        {
            Console.Clear();
            DisplayHeader("\tUser Inventory");

            Console.WriteLine("Item".PadLeft(10).PadRight(25) + "Value".PadLeft(10));
            Console.WriteLine("----------------------".PadRight(25).PadLeft(10) + "---------".PadLeft(10));

            foreach (StoreInventory userItem in userInventory)
            {
                Console.WriteLine(userItem.ItemInfo().PadRight(25).PadLeft(10));
                Console.WriteLine(userItem.Price.ToString("C2").PadLeft(35));
            }
            DisplayContinuePrompt();
        }

        static void DisplaySellInventory(List<StoreInventory> storeInventory, List<StoreInventory> userInventory)
        {
            string menuChoice;
            bool itemFound = false;

            Console.Clear();
            DisplayHeader("\tUser Inventory");

            Console.WriteLine("Item".PadRight(25) + "Value".PadLeft(10));
            Console.WriteLine("----------------------".PadRight(25) + "---------".PadLeft(10));

            foreach (StoreInventory userItem in userInventory)
            {
                Console.WriteLine(userItem.ItemInfo().PadRight(25));
                Console.WriteLine(userItem.Price.ToString("C2").PadLeft(35));
            }

            Console.WriteLine();
            Console.Write("Enter item to sell: ");
            menuChoice = Console.ReadLine().ToUpper();

            foreach (StoreInventory userItem in userInventory)
            {
                if (userItem.Name == menuChoice)
                {
                    storeInventory.Add(userItem);
                    userInventory.Remove(userItem);
                    Console.WriteLine($"You have sold your {userItem.Name}.");

                    itemFound = true;
                    break;
                }
            }
            if (!itemFound)
            {
                Console.WriteLine("You don't have that item to sell.");
            }

            DisplayContinuePrompt();
        }


        static StoreInventory InitializeStoreItemPotion()
        {
            StoreInventory potion = new StoreInventory();

            potion.Name = "POTION";
            potion.Price = 5;

            return potion;
        }
        static StoreInventory InitializeStoreItemSword()
        {
            StoreInventory sword = new StoreInventory();

            sword.Name = "SWORD";
            sword.Price = 15;

            return sword;
        }
        static StoreInventory InitializeStoreItemShield()
        {
            StoreInventory shield = new StoreInventory();

            shield.Name = "SHIELD";
            shield.Price = 5;

            return shield;
        }
        static StoreInventory InitializeStoreItemMeat()
        {
            StoreInventory meat = new StoreInventory();

            meat.Name = "MEAT";
            meat.Price = 2;

            return meat;
        }
    }
}
