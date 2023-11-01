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
    public static void print_xpixmap(string[] map, string[,] image, int width, int height)
    {
        Console.WriteLine("\n#define image_format 1");
        Console.WriteLine("#define image_width " + width);
        Console.WriteLine("#define image_height " + height);
        Console.WriteLine("#define image_ncolors 4");
        Console.WriteLine("#define image_chars_per_pixel 1");
        Console.WriteLine("static char *image_colors[] = {");
        for (int i = 0; i < 8; i++)
        {
            if (i % 2 == 0) { Console.Write("\"" + map[i] + "\","); }
            else if (i == 7)
            {
                Console.WriteLine("\"" + map[i] + "\"");
            }
            else
            {
                Console.WriteLine("\"" + map[i] + "\",");
            }
        }
        Console.WriteLine("};");
        Console.WriteLine("static char *image_pixels[] = {");
        for (int i = 0; i < height; i++)
        {
            Console.Write("\"");
            for (int j = 0; j < width; j++)
            {
                Console.Write(image[i, j]);
            }
            if (i == height - 1)
            {
                Console.WriteLine("\"");
            }
            else { Console.WriteLine("\","); }
        }
        Console.WriteLine("};");
    }
    public static bool check_color(string[] map, string color)
    {
        bool valid = false;
        foreach (string s in map)
        {
            if (s == color)
            {
                valid = true;
            }
        }
        return valid;
    }
    public static void replace_color(string[,] image,int width,int height,string color,string n_color)
    {
        for (int i = 0;i < height;i++) 
        { 
            for(int j = 0;j < width;j++)
            {
                if (image[i,j] == color)
                {
                    image[i,j] = n_color;
                }
            }
        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("[X PixMap Editor]");
        string[] color_map = new string[8];
        for (int i = 0; i < color_map.Length; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write("Enter a hexadecimal color for color " + (i / 2 + 1) + ": ");
                color_map[i + 1] = Console.ReadLine();
            }
            else
            {
                Console.Write("Enter a letter to represent this color: ");
                color_map[i - 1] = Console.ReadLine();
            }
        }
        Console.Write("\nEnter a width: ");
        int width = int.Parse(Console.ReadLine());
        Console.Write("Enter a height: ");
        int height = int.Parse(Console.ReadLine());
        string[,] image = new string[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                image[i, j] = color_map[0];
            }
        }

        int choice;
        do
        {
            Console.WriteLine("\nOptions:\n1) Set a color\n2) Replace colors\n3) Print X PixMap\n4) Quit");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {

                case 1:
                    Console.Write("\nEnter a row index: ");
                    int ridx= int.Parse(Console.ReadLine());
                    Console.Write("Enter a column index: ");
                    int cidx= int.Parse(Console.ReadLine());
                    Console.Write("Enter a color: ");
                    string color= Console.ReadLine();
                    if (check_color(color_map, color))
                    {
                        image[ridx, cidx] = color;
                        Console.WriteLine("Color updated!");
                    }
                    else
                    {
                        Console.WriteLine("Color is not in the color map!");
                    }
                    break;
                case 2:
                    Console.Write("\nEnter the color to replace: ");
                    string o_color= Console.ReadLine();
                    Console.Write("Enter the new color: ");
                    string n_color= Console.ReadLine();
                    if (check_color(color_map, o_color) && check_color(color_map, n_color))
                    {
                        replace_color(image,width,height,o_color,n_color);
                        Console.WriteLine("Color updated!");
                    }
                    else
                    {
                        Console.WriteLine("Color is not in the color map!");
                    }
                    break;
                case 3: 
                    print_xpixmap(color_map, image, width, height); 
                    break;
                case 4: 
                    Console.WriteLine("\n[Closing...]"); 
                    break;
                default: 
                    Console.WriteLine("\nInvalid choice"); 
                    break;
            }
        } while (choice != 4);

    }
}