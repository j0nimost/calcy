using System;
using System.Collections.Generic;

namespace calcy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Calcy, a nifty and easy to use math interpreter.");
            while(true)
            {
                Console.Write(">> ");
                string input = Console.ReadLine();

                if(input == "exit()")
                {
                    break;
                }

                try
                {
                    // generate tokens
                    Lexer lexer = new Lexer(input);
                    List<Tokens> tokens = lexer.Get_Tokens();
                    Console.WriteLine(">> {0}", lexer.ToString());
                    Parser parser = new Parser(tokens);
                    AST astObj = parser.ParseExp();
                    if(astObj == null)
                    {
                        continue;
                    }
                    Console.WriteLine(">> {0}", astObj.Eval());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
            }
        }
    }
}
