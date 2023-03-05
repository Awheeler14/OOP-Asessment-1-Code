using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {

            //creates the deck of cards 
            Pack D = new Pack();
            
            //so the code repeats until valid deal type is given 
            bool valid = false;
            //so code repeats unitl valid amount of cards to be dealt is given 
            bool deal_valid = false;
            //so code repeats until a valid amount of cards is given 
            bool amount_valid = false;

            while (!valid)
            {
                //asks for shuffle type 
                Console.WriteLine("What type of shuffle? (1 = Fisher-Yates|2 = Riffle|3 = No Shuffle");
                string shuffle_type = Console.ReadLine();

                //code only continues if valid shuffle given 
                if (shuffle_type == "1" || shuffle_type == "2" || shuffle_type == "3")
                {
                    D.shuffleCardPack(shuffle_type);

                    //ensure amount of cards being asked for is valid 
                    while (!deal_valid)
                    {
                        Console.WriteLine("Do you want one card dealt or multiple (o = one|m = multiple)");
                        string deal_type = Console.ReadLine();

                        if (deal_type == "o")
                        {
                            //outputs one cards information 
                            Card dealt_card = D.deal();
                            Console.WriteLine("suit is " + dealt_card.Suit);
                            Console.WriteLine("value is " + dealt_card.Value);

                            //exits program after a card dealt
                            Console.WriteLine("press enter to exit the program");
                            Console.ReadLine();
                            deal_valid = true;
                            valid = true;

                        }
                        //for multiple cards
                        else if (deal_type == "m")
                        {

                            while (!amount_valid)
                            {

                                //use try to ensure doesnt crash if cant convert input to interger
                                try
                                {
                                    Console.WriteLine("How many cards do you want dealt (2-52)");
                                    string amount = Console.ReadLine();
                                    int int_amount = Convert.ToInt32(amount);

                                    //makes sure can only deal amount of cards in deck 
                                    if (int_amount > 1 && int_amount < 53)
                                    {
                                        D.dealCard(int_amount);

                                        //exits program after multiple cards dealt
                                        Console.WriteLine("press enter to exit the program");
                                        Console.ReadLine();
                                        amount_valid = true;
                                        deal_valid = true;
                                        valid = true;
                                    }
                                    //error message
                                    else
                                    {
                                        Console.WriteLine("Not a valid amount of cards");
                                    }
                                }
                                //error message
                                catch
                                {
                                    Console.WriteLine("Not a valid amount of cards");
                                }
                            }
                            
                        }
                        //error message
                        else
                        {
                            Console.WriteLine("Please enter a valid deal type");
                        }

                   
                    }

                }
                //error message
                else
                {
                    Console.WriteLine("not a valid input");
                }

            }

        } 
    }
}
