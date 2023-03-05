using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CMP1903M_A01_2223
{
    class Pack
    {
        //unshuffled deck 
        protected Card[] _deck = new Card[52];

        public Card[] deck
        {
            get
            {
                return _deck;
            }
            set
            {
                _deck = value;
            }
        }

        public Pack()
        {

            int i;
            int j;
            //used to iterate through deck array
            int counter = 0;
            //uses Card class to generate a pack of cards through a double for loop
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 13; j++)
                {
                    //assigns suit and values
                    deck[counter] = new Card();
                    deck[counter].Suit = i + 1;
                    deck[counter].Value = j + 1;


                    //debug
                    //Console.WriteLine("suit is " + deck[counter].Suit);
                    //Console.WriteLine("value is " + deck[counter].Value);

                    counter = counter + 1;

                }
            }

           
        }

        //riffle shuffle pointless in code? dont see an algorithm for it online? therefore both lead to same shuffle as of now 

        public void shuffleCardPack(string typeOfShuffle)
        {

            //Shuffles the pack based on the type of shuffle
            if (typeOfShuffle == "1" || typeOfShuffle == "2")
            {
                Console.WriteLine("shuffle " + typeOfShuffle);

                //generates random for fisher yates shuffle
                Random r = new Random();

                //fisher yates shuffle, wont exceed length of array
                for (int n = deck.Length - 1; n > 0; --n)
                {
                    int k = r.Next(n + 1);

                    Card temp = deck[n];
                    deck[n] = deck[k];
                    deck[k] = temp;
                }
            }
            //feedback if not shuffle deck
            else if (typeOfShuffle == "3")
            {
                Console.WriteLine("The pack has not been shuffled");
            }

            //debug
            //int i;

            //for (i = 0; i <52; i++)
            //{
                //Console.WriteLine("suit is " + deck[i].Suit);
                //Console.WriteLine("value is " + deck[i].Value);
            //}

        }


        public Card deal()
        {
            //Deals one card
            return deck[0];
        }



        public void dealCard(int amount)
        {
        //Deals the number of cards specified by 'amount'
            for (int n = 0; n < amount; n++)
            {
                Console.WriteLine("suit is " + deck[n].Suit);
                Console.WriteLine("value is " + deck[n].Value);
            }
        }
    }
}
