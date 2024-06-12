using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;
//1. Stacken är en mängd av boxar som är staplade på varandra. Översta innehållet 
//används först. Innehållet som ligger under nås endast om den som är över lyfts av
//Heapen är att allt innehåll är tillgängligt på en gång med enkel åtkomst
//2. En reference type lagras på heapen medan en value type lagras där de lagras, kan vara
//på både stack eller heap.
//3. Den första returnerar 3 eftersom variable x tilldelas värdet 3, den andra returnerar 4
//eftersom MyValue tilldelas värdet 4
namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. ReverseText"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        ReverseText();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
             * 
                2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
                   När jag lägger till ett värde
                3. Med hur mycket ökar kapaciteten?
                   Med 4
                4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
                   I C# ökas inte kapaciteten linjärt
                5. Minskar kapaciteten när element tas bort ur listan?
                   Nej
                6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
                   När man vill minska antalet minnesallokeringar och kopieringar av 
                   element och öka kapaciteten expontiellt om det behövs

            */
            List<string> theList = new List<string>();
            bool run = true;
            while (run)
            { 
            string input = Console.ReadLine();
            char nav = input[0];
            string value = input.Substring(1);
                

            switch (nav)
            {
                case '+':
                    theList.Add(value);
                    Console.WriteLine("Capacitet: " + theList.Capacity);
                        Console.WriteLine("Count: " + theList.Count);
                        break;
                case '-':
                    theList.Remove(value);
                    Console.WriteLine("Capacitet: " + theList.Capacity);
                        Console.WriteLine("Count: " + theList.Count);
                        break;
                    case '0':
                        run = false;
                        break;
                    default:
                    Console.WriteLine("Use only + or -");
                    break;
            }
            }


        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
             * 
             * 
            */
            Queue queue = new Queue();
            bool run = true;

            while (run) { 
            string input = Console.ReadLine();
            char nav = input[0];
            string value = input.Substring(1);
            switch (nav)
            {
                case '+':
                    queue.Enqueue(value);
                    foreach (var element in queue)
                    {
                        Console.WriteLine(element);
                        }
                    break;
                case '-':
                    queue.Dequeue();
                        foreach (var element in queue)
                    {
                        Console.WriteLine(element);
                    }
                    break;
                case '0':
                        run = false;
                        break;
                    default:
                    Console.WriteLine("Use only + or -");
                    break;
            }
            }


        }
        //2
        static void ReverseText()
        {
            Stack stack = new Stack();
            string input = Console.ReadLine();
            char[] reverse = input.ToCharArray();
            foreach (char c in reverse)
            {
                stack.Push(c);
            }
            StringBuilder sb = new StringBuilder();
            foreach (char value in stack)
            {
                sb.Append(value);
            }
            Console.WriteLine("Reversed text: " + sb.ToString().Trim());

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
             * 1. Första objekten som lades kommer att vara lagrad nederst, ser inte bra ut
             * 
            */

            Stack stack = new Stack();
            bool run = true;
            while (run)
            {
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        stack.Push(value);
                        foreach (var element in stack)
                        {
                            Console.WriteLine(element);
                        }
                        break;
                    case '-':
                        stack.Pop();
                        foreach (var element in stack)
                        {
                            Console.WriteLine(element);
                        }
                        break;
                    case '0':
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Use only + or -");
                        break;
                }
            }
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             * 
             * 1. Anvander stack for att man ska kunna kolla forsta och sista parantesen med hjalp av FILO
             */

            Stack<char> stack = new Stack<char>();
            string input = Console.ReadLine();
            bool checkParentheses = false;

            foreach (char c in input) {
                if (c=='(' || c=='{' || c=='[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']') {

                    if (stack.Count != 0)
                    {
                        char c2 = stack.Pop();

                        if ((c == ')' && c2 == '(') ||
                            (c == '}' && c2 == '{') ||
                            (c == ']' && c2 == '['))
                        {
                            checkParentheses = true;
                        }
                    }

                }
            }
            if (checkParentheses)
            {
                Console.WriteLine("The string is well-formed");
            } else
            {
                Console.WriteLine("The string is not well-formed");
                Console.ReadLine();
            }

        }

    }
}

