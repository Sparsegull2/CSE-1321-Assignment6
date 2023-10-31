/* 
Class: CSE 1321L 
Section: #03 
Term: Fall 2023
Instructor: John Blake 
Name: Christopher Morrison
Lab#: Assignment6B
*/

using System;

class Assignment6B
{
    public static void print_xpixmap(string[] map, string[,] image,int width,int height)
    {
        Console.WriteLine("#define image_format 1");
        Console.WriteLine("#define image_width "+width);
        Console.WriteLine("#define image_height "+height);
        Console.WriteLine("#define image_ncolors 4");
        Console.WriteLine("#define image_chars_per_pixel 1");
        Console.WriteLine("static char *image_colors[] = {");
        for(int i=0;i<8;i++)
        {
            if (i % 2 == 0) { Console.Write("\"" + map[i] + "\","); }
            else
            {
                Console.WriteLine("\"" + map[i] + "\",");
            }
        }
        Console.WriteLine("};");
        Console.WriteLine("static char *image_pixels[] = {");
        for(int i=0;i<height;i++)
        {
            Console.WriteLine("\"");
            for(int j = 0; j < width; j++)
            {
                Console.Write(image[i,j]);
            }
            Console.WriteLine("\",");
        }
        Console.WriteLine("};");
    }
    public static bool check_color(string[] map, string color)
    {
        bool valid=false;
        foreach (string s in map)
        {
            if (s == color)
            {
                valid = true;
            }
        }
        return valid;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("[X PixMap Editor]");
        string[] color_map = new string[8];
        for(int i = 0; i < color_map.Length; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write("Enter a hexadecimal color for color " + (i / 2 + 1) + ": ");
                color_map[i+1] = Console.ReadLine();                
            }
            else
            {
                Console.Write("Enter a letter to represent this color: ");
                color_map[i-1] = Console.ReadLine();
            }
        }
        Console.Write("\nEnter a width: ");
        int width= int.Parse(Console.ReadLine());
        Console.Write("Enter a height: ");
        int height= int.Parse(Console.ReadLine());
        string[,] image = new string[height,width];

        int choice;
        do
        {
            Console.WriteLine("Options:\n1) Set a color\n2) Replace colors\n3) Print X PixMap\n4) Quit");
            Console.Write("Choice: ");
            choice =int.Parse(Console.ReadLine());
            switch (choice)
            {
                
                    case 1:
                    case 2:
                    case 3:print_xpixmap(color_map, image, width, height);break;
                    case 4:Console.WriteLine("\n[Closing...]");break;
                    default: Console.WriteLine("Invalid choice");break;
            }
        } while (choice != 4);

    }
}
