using System;
using System.IO;
using System.Collections.Generic;
namespace Assignment_1
{
    class Program
    {
        /*
         Problem Statement: Write a C# code to read a csv file, the first element is the name of the country, the second element is the time in that country in GMT format and calculate the time equivalent for that country to India's time and make it the third element in the csv file.
         */
        public static void function()
        {
            // Creating a file and writing some dummy values.
            string filepath = @"C:\Users\Palbis\OneDrive - Lenze SE\Training_Practice\Assignment_1\ifile.csv";
            string[] lines = { "USA,10:00:00", "China,14:00:00", "Russia,04:00:00", "Japan,11:00:00"};
            File.WriteAllLines(filepath, lines);

            DateTime dt = DateTime.Today;


            // Reading all the lines from the file and storing it into the an array
            string[] file_lines = File.ReadAllLines(filepath);
            string[] each_line = new string[file_lines.Length];

            // creating a new file for the output.
            string ofilepath = @"C:\Users\Palbis\OneDrive - Lenze SE\Training_Practice\Assignment_1\ofile.csv";
            List<String> ol = new List<string>();
            for (int i = 0; i < file_lines.Length; i++)
            {
                each_line = file_lines[i].Split(',');
                string country = each_line[0];
                string time = each_line[1];

                // taking out the time component from the input
                var splittime = time.Split(':');
                var thr = splittime[0];
                var tmin = splittime[1];
                var tsec = splittime[2];
                int hr = int.Parse(thr);
                int min = int.Parse(tmin);
                int sec = int.Parse(tsec);

                switch(country)
                {
                    case "USA":
                        DateTime ct = new DateTime(dt.Year, dt.Month, dt.Day, hr, min, sec);
                        DateTime ot = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(ct, "Eastern Standard Time", TimeZoneInfo.Local.Id);
                        string o = country + "," + time + "," + ot;
                        ol.Add(o);
                        break;
                    case "China":
                        DateTime kt = new DateTime(dt.Year, dt.Month, dt.Day, hr, min, sec);
                        DateTime t = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(kt, "China Standard Time", TimeZoneInfo.Local.Id);
                        string l = country + "," + time + "," + t;
                        ol.Add(l);
                        break;
                    case "Japan":
                        DateTime jt = new DateTime(dt.Year, dt.Month, dt.Day, hr, min, sec);
                        DateTime j = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(jt, "Tokyo Standard Time", TimeZoneInfo.Local.Id);
                        string jp = country + "," + time + "," + j;
                        ol.Add(jp);
                        break;
                    case "Russia":
                        DateTime rt = new DateTime(dt.Year, dt.Month, dt.Day, hr, min, sec);
                        DateTime r = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(rt, "Russian Standard Time", TimeZoneInfo.Local.Id);
                        string m = country + "," + time + "," + r;
                        ol.Add(m);
                        break;
                }
            }
            File.WriteAllLines(ofilepath, ol);
            Console.WriteLine("Converted time for each country entered in file");
        }
        

        static void Main(string[] args)
        {
            function();
        }
    }
}
