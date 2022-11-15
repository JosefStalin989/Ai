using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Snake
{
    class Program
    {
        struct Point //använder struct (värdevariabel) istället för class
        {
            public Point(int x, int y) //anger värde för x, y
            {
                X = x;
                Y = y;
            }

            public int X { get; }
            public int Y { get; }

        }




        static void Main(string[] args)
        {

            string[,] Dictionary =
            {
                {". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". "},
                {". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". "},
                {". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". "},
                {". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". "},
                {". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". "},
                {". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". "},
                {". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". "},
                {". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". "},
                {". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". "},
                {". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". "},
               

            };
            Random rd = new Random();
            int randomX = rd.Next(0, 9);
            int randomY = rd.Next(0, 9);
            //Point candyPosition = new Point rd.Next(3, 3); //fel ställe för rd.Next?
            Point candyPosition = new Point(randomX, randomY); 
            


            Point direction = new Point(-1, 0); //masken går uppåt vid start
            List<Point> masken = new List<Point>();
            masken.Add(new Point(4, 4));
            masken.Add(new Point(4, 4));
            masken.Add(new Point(4, 4));
            
            
            //candy variabel nedan
           
            List<Point> candy = new List<Point>();
            candy.Add(candyPosition);
        


           


                while (true)
                {
                    Console.Clear();

                    //två for loops "ritar" candy & snake
                    for (int row = 0; row < Dictionary.GetLength(0); row++)
                    {
                        for (int cell = 0; cell < Dictionary.GetLength(1); cell++)
                        {
                            Point currentPosition = new Point(row, cell);
                        
                        //slump funktion här
                        if (masken.Contains(candyPosition))
                        {
                            int randX = rd.Next(0, 9);
                            int randY = rd.Next(0, 9);
                            candyPosition = new Point(randX, randY); 
                            candy.RemoveAt(candy.Count - 1);
                            candy.Add (candyPosition); 
                            masken.Add(new Point(4, 4));
                        }
                   

                        if (masken.Contains(currentPosition)) //contains går igenom listan tills korrekt värde hittas
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("  ");
                            } else if (candy.Contains(currentPosition))
                          
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write("  ");
                        }
                            else
                        {
                            Console.Write(Dictionary[cell, row]); //fortsätter samtidigt rita ut kartan om inget korrekt värde hittas
                        }

                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine();
                    }

               


                    Stopwatch sw = Stopwatch.StartNew();
                    while (sw.ElapsedMilliseconds < 400) //väntar på nytt input/respons
                    {
                        if (Console.KeyAvailable)      //styr masken med vänster & högerpil
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.RightArrow)
                            {
                                direction = new Point(direction.Y, -direction.X);
                            }

                            if (key.Key == ConsoleKey.LeftArrow)
                            {
                                direction = new Point(-direction.Y, direction.X);
                            }
                        }
                    }


                    //gör förflyttning och logik etc
                    Point head = masken[0];
                    Point newPosition = new Point(head.X + direction.X, head.Y + direction.Y);
                if (newPosition.Y >= 10)
                    {
                    Console.WriteLine("Game Over");
                    break;
                    }
                if (newPosition.Y <= -1)
                {
                    Console.WriteLine("Game Over");
                    break;
                }
                
                if (newPosition.X <= -1)
                {
                    Console.WriteLine("Game Over");
                    break;
                }

                if (newPosition.X >= 10)
                {
                    Console.WriteLine("Game Over");
                    break;
                }

                if (masken.Contains(newPosition))
                {
                    Console.WriteLine("Game Over idiot");
                    break;
                }

                    masken.Insert(0, newPosition);
                    masken.RemoveAt(masken.Count - 1); //tar bort svans 
                    
                
                
            }
            }
        }
    }
