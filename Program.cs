using System;
using System.Drawing;

namespace imageToASCII
{
    class Program
    {
        static string path;
        static int pixelInterval = 8;
        static double brightnessMultiplier = 1;

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Title = "Image to ASCII convertor";
            Console.WriteLine("__________________________________________________");
            Console.WriteLine("To create an image, type the following:");
            Console.WriteLine("path; pixel interval; brightness multiplier");
            Console.WriteLine("The default values are: pixel interval = {0}, brightness multiplier = {1}", pixelInterval, brightnessMultiplier);
            Console.WriteLine(@"Example: C:\Users\User\Pictures\FunnyCat.png; 8; 1");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");


            string input = Console.ReadLine();
            string[] inputSplit = input.Split(';');

            path = inputSplit[0];

            if (inputSplit.Length > 1 && int.TryParse(inputSplit[1], out int intervalOut))
            {
                pixelInterval = intervalOut;
            }

            if (inputSplit.Length > 2 && double.TryParse(inputSplit[2], out double brightnessOut))
            {
                brightnessMultiplier = brightnessOut;
            }


            try
            {
                Console.Clear();
                ConvertToText();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("_____________________________________________________________");
                Console.WriteLine(e);
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Seems that you've typed incorrect directory, please try again", Console.ForegroundColor = ConsoleColor.White);
                Console.WriteLine("");
                Main();
            }
        }

        static void ConvertToText()
        {
            Bitmap bmp = (Bitmap)Image.FromFile(path);
            string WrittenLine = "";
            for (int y = 0; y < bmp.Size.Height - (bmp.Size.Height % pixelInterval); y += pixelInterval)
            {
                for (int x = 0; x < bmp.Size.Width; x++)
                {
                    if (x % pixelInterval == 0 || x % pixelInterval == 1) // Poměr výšky a šířky znaku je přibližně 2/1
                    {
                        WrittenLine += GetSymbolFromBrightness(bmp.GetPixel(x, y).GetBrightness() * brightnessMultiplier);
                    }
                }

                Console.WriteLine(WrittenLine);
                WrittenLine = "";
            }
            Console.WriteLine("");

            void OptionChoice()
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Create new ASCII - 1\nExit program - 2");
                string desiredOperation = Console.ReadLine();

                switch (desiredOperation)
                {
                    case "1":
                        Console.Clear();
                        Main();
                        break;

                    case "2":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Option {desiredOperation} doesn't exist", Console.ForegroundColor = ConsoleColor.White);
                        Console.WriteLine("");
                        OptionChoice();
                        break;

                }
            }
            OptionChoice();
            

        }
        static string GetSymbolFromBrightness(double brightness)
        {
            switch ((int)(brightness * 10))
            {
                case 0:
                    return "@";
                case 1:
                    return "$";
                case 2:
                    return "#";
                case 3:
                    return "*";
                case 4:
                    return "!";
                case 5:
                    return "+";
                case 6:
                    return ":";
                case 7:
                    return "~";
                case 8:
                    return "-";
                case 9:
                    return ".";
                default:
                    return " ";
            }
        }
    }
}