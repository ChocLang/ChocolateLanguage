using System;

using ChocolateRuntime;

namespace Chocolate {
    public static class Program {

        static string[] ValidArguments = { "--r", "--run", "--help", "--h", "--compile:graphics", "--c:g", "--compile", "--c", "--version", "--v" };

        // Checks for arguments and sends them to the DoArgs function, and if none, shows an error
        static int Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("Error: No argument specified \n");

                // Prints how to get a list of arguments
                Console.WriteLine("Run with --help or --h for a list of available arguments");
                return -1;
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
                        Console.WriteLine("--help or --h: Shows this list \n --version or --v: Shows the compiler version \n --run or --r filename: Runs the code in the console (for text only programs) \n --compile or --c  filename: compiles to an executable (for text programs) \n --compile:graphics or --c:g filename: To compile with graphics, using WPF and SharpGL");
                        break;
                    case "--version":
                    case "--v":
                        Console.WriteLine($"Chocolate Compiler v{v}");
                        break;
                    case "--r":
                    case "--run":
                        try {
                            Run(args[i + 1]);
                        }
                        catch (Exception e) {
                            if (e.GetType() == typeof(IndexOutOfRangeException)) {
                                Console.WriteLine("Error: No file specified");
                            }
                        }
                        continue;
                    case "--compile":
                    case "--c":
                        // To be added
                        break;
                    case "--compile:graphics":
                    case "--c:g":
                        // To be added
                        break;
                    default: return -1;
                }
                i++;
            }

            return 0;
        }

        static void Run(string fName) {
            Compiler compiler = new Compiler(fName);
            ReturnCode RetCode = compiler.Run();
            if (RetCode != ReturnCodes.CH0000) {
                Console.WriteLine(RetCode.Message);
			}
        }
    }
}