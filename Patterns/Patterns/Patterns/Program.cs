using System;


    public class Patterns
    {
         public static void Main()
        {
            Console.WriteLine("Hello World!");
         patternOne();
         patternTwo();
         patternThree();

        }

         private static void patternOne()
        {
        Console.WriteLine("Pattern One :");
        for(int i=1; i<=5;i++)
        {
            for(int j=1; j<=5; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

            Console.ReadKey(true);
        }


    private static void patternTwo()
    {
        Console.WriteLine("Pattern Two");
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
        Console.ReadKey(true);

    }

    private static void patternThree()
    {
        Console.WriteLine("Pattern Three");
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                Console.Write(j);
            }
            Console.WriteLine();
        }
        Console.ReadKey(true);

    }

}

