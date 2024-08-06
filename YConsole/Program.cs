using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YConsole
{
    internal class Program
    {
        static bool logoned;
        static string read;
        static int nummer_of_errors = 0;
        static void Main()
        {
            Console.Title = "YConsole";
            Console.WriteLine("(C) 2024 YoungBat,Inc.");
            main:
            Console.Write(">");
            read = Console.ReadLine();
	        read.ToLower();
            if (logoned == true)
            {
                switch (read)
                {
                    case "display file": display(); break;
                    case "display dir": display(); break;
                    case "display text": display(); break;
                    case "logon": Console.WriteLine("You are logoned!");goto main;
                    case "exit": Environment.Exit(0); break;
                    default:Console.WriteLine("Error");goto main;
                }
            }
            else
            {
                switch (read)
                {
                    case "display file": display(); break;
                    case "display dir": display(); break;
                    case "display text": display(); break;
                    case "logon": logon();break;
                    case "exit": Environment.Exit(0); break;
                    default: Console.WriteLine("Error"); goto main;
                }
            }
            
        }

        static void logon()
        { 
            string cheakfile = "password";

            logon:
            if (File.Exists(cheakfile))
            {
                
                Console.WriteLine("Please enter your password:");
                string read2 = Console.ReadLine();
                string read3 = File.ReadAllText(cheakfile);
                if (read2 == read3)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome!Will logon after 5 s.");
                    Thread.Sleep(5000);
                    logoned = true;
                    Console.Clear();
                    read = "";
                    Main();
                }
                else
                {
                    Console.WriteLine("Password is error!");
                    nummer_of_errors = ++nummer_of_errors;
                    if (nummer_of_errors == 3)
                    {
                        Console.WriteLine("Error!Will exit after 5 s!");
                        Thread.Sleep(5000);
                        Environment.Exit(0);
                    }
                    goto logon;
                }
            }
            else
            {
                File.Create(cheakfile).Dispose();
                Console.WriteLine("Please enter your password:");
                string read1 = Console.ReadLine();
                File.WriteAllText(cheakfile, read1);
                Console.Clear();
                goto logon;
            }
        }

        static void display()
        {
            switch (read)
            {
                case "display file":
                    Console.WriteLine("Please enter path:");
                    string path = Console.ReadLine();
                    if (Directory.Exists(@path))
                    {
                        try
                        {
                            string[] files = Directory.GetFiles(@path);
                            Console.WriteLine(String.Join("\n", files));
                            read = "";
                            Main();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error!");
                            read = "";
                            Thread.Sleep(3000);
                            Main();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                        read = "";
                        Thread.Sleep(3000);
                        Main();
                    }
                    break;
                case "display dir":
                    Console.WriteLine("Please enter path:");
                    string path2 = Console.ReadLine();
                    if (Directory.Exists(@path2))
                    {
                        try
                        {
                            string[] dirs = Directory.GetDirectories(@path2);
                            Console.WriteLine(String.Join("\n", dirs));
                            read = "";
                            Main();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error!");
                            read = "";
                            Thread.Sleep(3000);
                            Main();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                        read = "";
                        Thread.Sleep(3000);
                        Main();
                    }
                    break;
                case "display text":
                    Console.WriteLine("Please enter text:");
                    string text = Console.ReadLine();
                    Console.WriteLine(text);
                    read = "";
                    Main();
                    break;
                default:
                    Console.WriteLine("Error!");
                    read = "";
                    Thread.Sleep(3000);
                    Main();
                    break;
            }
            
            
        }
    }
}
