using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace NP_Project_Client
{
    public class Client
    {
        TcpClient client;


        public void Game(TcpClient client)
        {
            this.client = client;
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());

            Console.WriteLine("GAME START");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("SERVER PLACE A BOMB ");
            Console.WriteLine("GUESS THE BLOCK WHERE BOMB HAS BEEN PLACED");
            Console.WriteLine("************************************************************");
            Console.WriteLine("Block");
            Console.WriteLine("     1    |   2   |    3");
            Console.WriteLine("     4    |   5   |    6");
            Console.WriteLine("     7    |   8   |    9");
            Console.WriteLine("================================");

            int clientPoints = 0;

            while (clientPoints < 2)
            {
                string bomb = reader.ReadLine();

                for (int i = 1; i < 4; i++)
                {
                    Console.WriteLine("SERVER PLACED A BOMB , GUESS THE BLOCK AND DIFFUSE THE BOMB  --- TOTAL ATTEMPS 3");
                    Console.WriteLine("ATTEMP NUMBER : " + i);

                    Console.WriteLine("     1    |   2   |    3");
                    Console.WriteLine("     4    |   5   |    6");
                    Console.WriteLine("     7    |   8   |    9");

                    Console.WriteLine("GUESS..");
                    string guessBomb = Console.ReadLine();
                    if (guessBomb == bomb)
                    {
                        Console.WriteLine("-----------WELL DONE!! BOMB DIFFUSED SUCCESFULLY-----------");
                        clientPoints++;

                        break;
                    }
                }

                Console.WriteLine("client Points: " + clientPoints);
                if (clientPoints == 2)
                {
                    Console.WriteLine("------------------client win-------------");
                    Console.WriteLine("Total CLIENT POINT: " + clientPoints);
                    break;
                }

                Console.WriteLine("place bomb in given Block");
                Console.WriteLine("     1    |   2   |    3");
                Console.WriteLine("     4    |   5   |    6");
                Console.WriteLine("     7    |   8   |    9");
                Console.WriteLine("");
                Console.WriteLine(" YOUR TURN TO PLACE BOMB FROM ANY ABOVE BLOCKS");
                Console.WriteLine("PLACE A BOMB");
                string placeBomb = "";
                placeBomb = Console.ReadLine();


                if (placeBomb == "1" || placeBomb == "2" || placeBomb == "3" || placeBomb == "4" || placeBomb == "5" || placeBomb == "6" || placeBomb == "7" || placeBomb == "8" || placeBomb == "9")
                {
                    Console.WriteLine("BOMB HAS BEEN PLACED AT BLOCK : " + placeBomb);

                    writer.WriteLine(placeBomb);
                    writer.Flush();
                }
                else
                {
                    Console.WriteLine(" Invalid Input ");
                    writer.WriteLine("none");
                    writer.Flush();
                }
            }

            Console.ReadLine();

            reader.Close();
            writer.Close();
            client.Close();

        }

    }
    class Program
    {
        static void Main(string[] args)
        {


            //start
            Console.WriteLine("This is client");


            try
            {

                TcpClient client = new TcpClient("127.0.0.1", 8080);
              //  StreamReader reader = new StreamReader(client.GetStream());
               // StreamWriter writer = new StreamWriter(client.GetStream());

                Client ob = new Client();
                ob.Game(client);

            }


            catch (Exception e)
            {
                Console.WriteLine(e);
            }




          
        }


    }

}
