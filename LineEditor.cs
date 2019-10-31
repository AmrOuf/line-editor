using System;

struct Program
{
    public static void PrintBackground(int lineLength)
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;

        for (int i = 0; i < lineLength; i++)
        {
            Console.Write(" ");
        }

        Console.SetCursorPosition(0, 0);

        //Console.ResetColor();
    }

    public static void WriteinEditor(char[] input)
    {
        int currentIndex = 0;
        int firstIndex = 0;
        int lastIndex = 0;
        ConsoleKeyInfo cki;
        bool isInsert = false;

        while ((cki = Console.ReadKey(true)).Key != ConsoleKey.Enter && (currentIndex < 10))
        {
            if (Char.IsLetterOrDigit(cki.KeyChar))
            {
                //store it with default mode or insert?
                if(isInsert)
                {
                    lastIndex++;
                    for(int i=lastIndex; i>=currentIndex; i--)
                    {
                        if(i<10)
                            input[i] = input[i - 1];

                    }
                    input[currentIndex] = cki.KeyChar;
                    currentIndex++;
                    if (currentIndex >= lastIndex)
                        lastIndex++;
                }
                else
                {
                    input[currentIndex] = cki.KeyChar;
                    currentIndex++;
                    if (currentIndex >= lastIndex)
                        lastIndex++;
                }
            }
            else
            {
                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        currentIndex--;
                        if (currentIndex < 0)
                            currentIndex = 0;
                        break;
                    case ConsoleKey.RightArrow:
                        currentIndex++;
                        if (currentIndex >= 10)
                            currentIndex = 9;
                        break;
                    case ConsoleKey.Home:
                        currentIndex = 0;
                        break;
                    case ConsoleKey.End:
                        currentIndex = lastIndex;
                        break;
                    case ConsoleKey.Insert:
                        isInsert = isInsert ? false : true;
                        break;
                    default:
                        break;
                }
            }

            if (lastIndex >= 10)
                lastIndex = 9;

            //Printing from the array
            Console.SetCursorPosition(0, 0);
            if(isInsert)
            {
                for (int i = 0; i <= lastIndex && i<10; i++)
                    Console.Write(input[i]);
                Console.SetCursorPosition(currentIndex, 0);
            }
            else
            {
                for (int i = 0; i < currentIndex; i++)
                    Console.Write(input[i]);
            }

            if (currentIndex == 10)
            {
                currentIndex--;
                Console.SetCursorPosition(9, 0);
            }
        }

        Console.SetCursorPosition(0, 5);

        for (int i = 0; i < 10; i++)
            Console.Write(input[i]);
    }

    public static void Main()
    {
        PrintBackground(10); 
        char[] input = new char[10];
        WriteinEditor(input);
        Console.ResetColor();

        //Console.ReadLine();
    }
}
