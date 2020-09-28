using System;

namespace NumberGenerator_fForProcedural_
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.Title = "Procedural Generator";
            int buf = 30; //margin to the right of console for input
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string intro = "This App wil generate proceduraly integer numbers"; //change
            Console.SetCursorPosition((Console.WindowWidth - intro.Length) / 2, Console.CursorTop);
            Console.Write(intro);
            Console.Write("\n\n\tAt any time press \"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\" to continue or type \"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("quit");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\" to quit.");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.CursorLeft = Console.BufferWidth - buf;
            string quit = Console.ReadLine();
            if (quit.Trim().ToLower() == "quit") return;

            bool repeatKey = true;
            while (repeatKey == true)
            {
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string introKey = "Key Settings"; //change
                Console.SetCursorPosition((Console.WindowWidth - introKey.Length) / 2, Console.CursorTop);
                Console.Write(introKey);

                Console.Write("\n");
                int size;
                int min;
                int max;
                bool proceed = false;
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("\n\t\tEnter the Minimum value");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.CursorLeft = Console.BufferWidth - buf;
                    string tryParce = Console.ReadLine();
                    if (tryParce == "quit") return;
                    if (Int32.TryParse(tryParce, out min))
                    {
                        if (min >=0||min<=8)
                        {
                            proceed = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\n\t\tOnly values between \"0\" and \"8\" are accepted.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\n\t\tYour input must be an integer.");
                    }
                } while (!proceed);
                proceed = false;
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("\n\t\tEnter the Maximum value");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.CursorLeft = Console.BufferWidth - buf;
                    string tryParce = Console.ReadLine();
                    if (tryParce == "quit") return;
                    if (Int32.TryParse(tryParce, out max))
                    {
                        if (max >= 1 || max <= 9)
                        {
                            proceed = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\n\t\tOnly values between \"1\" and \"9\" are accepted.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\n\t\tYour input must be an integer.");
                    }
                } while (!proceed);
                proceed = false;
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("\n\t\tEnter the size of the Key");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.CursorLeft = Console.BufferWidth - buf;
                    string tryParce = Console.ReadLine();
                    if (tryParce == "quit") return;
                    if (Int32.TryParse(tryParce, out size))
                    {
                        if (size != 0)
                        {
                            proceed = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\n\t\t\"0\" is not a valid Key size.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\n\t\tYour input must be an integer.");
                    }
                } while (!proceed);

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                string[] k = new string[size];

                int i = 0;
                while (i <= size - 1)
                {
                    k[i] = rnd.Next(min, max).ToString();
                    i++;
                }

                string key = String.Concat(k).Trim();
                bool repeatSeed = true;
                while (repeatSeed == true)
                {
                    Console.Write("\n");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    string introSeed = "Number Settings"; //change
                    Console.SetCursorPosition((Console.WindowWidth - introSeed.Length) / 2, Console.CursorTop);
                    Console.Write(introSeed);

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("\n\n\t\tYour Key is: ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(key);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("\n\n");

                    int seed = 0;
                    proceed = false;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("\n\t\tEnter the seed: ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.CursorLeft = Console.BufferWidth - buf;
                        string tryParce = Console.ReadLine();
                        switch (tryParce)
                        {
                            case "next key":
                                repeatSeed = false;
                                proceed = true;
                                break;
                            case "quit":
                                repeatSeed = false;
                                repeatKey = false;
                                proceed = true;
                                break;
                            default:
                                if (Int32.TryParse(tryParce, out seed))
                                {
                                    proceed = true;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("\n\t\tYour input must be an integer.");
                                }
                                break;
                        }
                        
                    } while (!proceed);

                    if (repeatSeed != false)
                    {
                        int currentPosition = seed; //default

                        int length = 1;
                        proceed = false;
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("\n\t\tHow many digits you need: ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.CursorLeft = Console.BufferWidth - buf;
                            string tryParce = Console.ReadLine();
                            switch (tryParce)
                            {
                                case "next key":
                                    repeatSeed = false;
                                    break;
                                case "quit":
                                    repeatSeed = false;
                                    repeatKey = false;
                                    break;
                                default:
                                    if (Int32.TryParse(tryParce, out length))
                                    {
                                        if (length != 0)
                                        {
                                            if (length >= size)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write("\n\t\tLength can't be equal or higher than the key.");
                                            }
                                            else
                                            {
                                                proceed = true;
                                            }
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.Write("\n\t\tLength can't be \"0\"");
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write("\n\t\tYour input must be an integer.");
                                    }
                                    break;
                            }
                        } while (!proceed);

                        if (repeatSeed != false)
                        {

                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("\n\n\t\tYour seed is ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(seed);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(" we will generate ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(length);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(" digit long numbers proceduraly.");

                            Console.Write("\n\n\t\t\tType \"");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("next seed");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("\" to try other seed, \"");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("next key");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("\" to get other key or press \"");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Enter");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("\" for next Iteration. \n\n");

                            string pad = new String('0', length);
                            int iteration = 0;

                            bool repeatIteration = true;
                            while (repeatIteration == true)
                            {
                                iteration++;

                                currentPosition += length;

                                if (currentPosition + length > key.Length)
                                {
                                    currentPosition -= key.Length;
                                    if (currentPosition < 0) currentPosition = 0;
                                }

                                string currentNum = key.Substring(currentPosition, length);

                                Console.Write("\t\t\tSeed:");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write(seed);
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("\tIteration:");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write(iteration);
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("\tYour number:");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write(currentNum);
                                //Console.Write(ulong.Parse(currentNum).ToString(pad)); //for real aplication

                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.CursorLeft = Console.BufferWidth - buf;

                                string command = Console.ReadLine().Trim();
                                switch (command)
                                {
                                    case "next seed":
                                        repeatIteration = false;
                                        repeatSeed = true;
                                        break;

                                    case "next key":
                                        repeatIteration = false;
                                        repeatSeed = false;
                                        break;
                                    case "quit":
                                        repeatIteration = false;
                                        repeatSeed = false;
                                        repeatKey = false;
                                        break;
                                }
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                            }
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\tPress Enter to quit");
            Console.CursorLeft = Console.BufferWidth - buf;
            Console.ReadLine();
        }
    }
}
