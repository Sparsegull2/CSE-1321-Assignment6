/* 
Class: CSE 1321L 
Section: #03 
Term: Fall 2023
Instructor: John Blake 
Name: Christopher Morrison
Lab#: Assignment6A
*/

using System;

class Assignment6A
{
    public static void print_array(float[,] myArray,int width,int height)
    {
        for (int i=0;i<height;i++)
        {
            for(int j = 0; j < width; j++)
            {
                Console.Write(myArray[i,j]+", ");
            }
            Console.WriteLine();
        }
    }
    public static bool updateRow(float[,]myArray,int width,int height,int ridx,int cidx,int length,float value) 
    {
        if (ridx > height || cidx > width || length > (width - cidx) || ridx < 0 || cidx < 0)
        {
            return false;
        }
        else
        {
            for (int i = cidx; i < cidx+length; i++)
            {
                myArray[ridx, i] = value;
            }
            return true;
        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("[Building Character]");
        Console.Write("Enter an array width: ");
        int width = int.Parse(Console.ReadLine());
        Console.Write("Enter an array height: ");
        int height = int.Parse(Console.ReadLine());
        Console.Write("Enter an initial value: ");
        float value = float.Parse(Console.ReadLine());
        float[,] myAry = new float[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                myAry[i,j] = value;
            }
        }
        Console.WriteLine("\nCreating an array with "+height+" row(s) and "+width+" column(s)") ;
        Console.WriteLine();
        print_array(myAry, width, height);
        Console.WriteLine("\nMaking the first row negative\n");
        updateRow(myAry, width, height,0,0,width,value*(0-1));
        print_array(myAry,width, height);
        Console.Write("\nEnter a row index: ");
        int ridx=int.Parse(Console.ReadLine());
        Console.Write("Enter a column index: ");
        int cidx=int.Parse(Console.ReadLine());
        Console.Write("Enter a value: ");
        value = float.Parse(Console.ReadLine());
        Console.WriteLine() ;
        updateRow(myAry,width,height,ridx,cidx,1,value);
        print_array(myAry,width,height);
        Console.WriteLine("\nAlternating rows");
        Console.WriteLine();
        for(int i = 0; i < height; i++)
        {
            if (i % 2 == 0) value = 12.78f;
            else value = 87.21f;
            updateRow(myAry,width,height,i,0,width,value);
        }
        print_array(myAry,width,height);
        bool cont = true;
        while (cont)
        {
            Console.Write("\nEnter a row index: ");
            ridx = int.Parse(Console.ReadLine());
            Console.Write("Enter a column index: ");
            cidx = int.Parse(Console.ReadLine());
            Console.Write("Enter a length: ");
            int length = int.Parse(Console.ReadLine());
            Console.Write("Enter a value: ");
            value = float.Parse(Console.ReadLine());
            if (updateRow(myAry, width, height, ridx, cidx, length, value) == false)
            {
                Console.WriteLine("\nInvalid information! Try again.");
                Console.WriteLine();
            }
            else
            {
                print_array(myAry,width,height);
                cont = false;
                Console.WriteLine("\n[Finally done!]");
            }
        }
    }
}
