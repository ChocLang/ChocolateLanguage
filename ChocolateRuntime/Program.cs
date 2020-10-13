using System;
using System.IO;
using System.Reflection.PortableExecutable;

namespace Chocolate {
    public static class Program {

        static string[] ValidArguments = {"--r", "--run", "--help", "--h", "--compile:graphics", "--c:g", "--compile", "--c", "--version", "--v"};

        // Checks for arguments and sends them to the DoArgs function, and if none, shows an error
        static int Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("Error: No argument specified \n");
                // Prints how to get a list of arguments
                Console.WriteLine("Run with --help or --h for a list of available arguments");

                return 1;
            }

            return DoArgs(args);            
        }

        // Runs appropriately according to the arguments
        static int DoArgs(string[] args) {
            string v = "1.0.0-alpha";
            foreach (var arg in args) {
                int i = 0;
                switch (arg) {
                    case "--help":
                    case "--h":
                        // Prints the list of arguments
                        string s = "Chocolate Compiler Options";
                        Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                        Console.WriteLine(s);
                        Console.SetCursorPosition(1, Console.CursorTop);
                        Console.WriteLine("--help or --h: Shows this list \n --version or --v: Shows the compiler version \n --run or --r: Runs the code in the console (for text only programs) \n --compile or --c: compiles to an executable (for text programs) \n --compile:graphics or --c:g to compile with graphics, using WPF and SharpGL");
                        break;
                    case "--version":
                    case "--v":
                        Console.WriteLine($"Chocolate Compiler v{v}");
                        break;
                    case "--r":
                    case "--run":
                        
                        break;
                    case "--compile":
                    case "--c":
                        // To be added
                        break;
                    case "--compile:graphics":
                    case "--c:g":
                        // To be added
                        break;
                    default:
                        // Checks if it is an invalid argument or parameter for an argument
                        if (arg.StartsWith("--") && Array.IndexOf(ValidArguments, arg) < 0) {
                            // Prints how to get a list of arguments
                            Console.WriteLine($"Error: Invalid option \"{arg}\"\n");
                            Console.WriteLine("Run with --help for a list of available arguments");
                        }
                        break;
                }
                i++;
            }

            return 0;
        }
    }
}
