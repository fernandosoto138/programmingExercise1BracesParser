using System;
using System.Collections.Generic;

namespace testConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Analyzing...");
            String[] trueTests = { "{}", "({})", "{}()[]" };
            String[] falseTests = { "(", "{}(", "{(})", "[]()]" };
            Console.WriteLine("Good Braces");
            foreach( String T in trueTests)
            {
                if (Analize(T))
                    Console.WriteLine("Passed : " + T);
                else
                    Console.WriteLine("Error : " + T);
            }
            Console.WriteLine("\nBad Braces");
            foreach (String F in falseTests)
            {
                if (!Analize(F))
                    Console.WriteLine("Passed : " + F);
                else
                    Console.WriteLine("Error : " + F);
            }
        }

        public static bool Analize(String text)
        {
            char openP = '(';
            char openB = '[';
            char openC = '{';
            char closeP = ')';
            char closeB = ']';
            char closeC = '}';
            char[] open = { openP, openB, openC };
            char[] close = { closeP, closeB, closeC };
            //Check for Open and close Braces
            List<int> openIndexes= new List<int>();
            List<int> closeIndexes = new List<int>();
            Stack<char> closeChar = new Stack<char>();

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < open.Length;j++)
                {
                    if(open[j] == text[i])
                    {
                        openIndexes.Add(i);
                        //If there are an open brace we will expect the 
                        //close brace in a stack way.
                        closeChar.Push(close[j]);
                    }
                }
                for (int j = 0; j < close.Length; j++)
                {
                    if (close[j] == text[i])
                    {
                        closeIndexes.Add(i);
                        //If there any close brase
                        if (closeChar.Count > 0)
                        {
                            //the close brace needs to be equivalent
                            //to the expected close brace 
                            if (closeChar.Peek() != close[j])
                                return false;
                            else
                                closeChar.Pop();
                        }

                    }
                }
            }
            if (openIndexes.Count != closeIndexes.Count)
                return false;

            return true;
           
        }
    }
}
