using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualBasic.CompilerServices;

namespace StefanDateTimeDemo
{
    class Program
    {
        static void SkapaDatumOchSkrivUt()
        {
            //Skapa idag
            DateTime datum = DateTime.Now;
            
            Console.WriteLine(datum);
            Console.WriteLine(datum.ToString("yyyy-MM-dd"));

            Console.WriteLine(datum.ToString("hh:mm:ss"));
        }

        static void ConstructAnyDate()
        {
            DateTime stefansFoddes = new DateTime(1972,8,3);
            Console.WriteLine(stefansFoddes);
            Console.WriteLine($"Det var på en {stefansFoddes.DayOfWeek}");

            var n = DateTime.Now;
            ;
            if (n.DayOfWeek == DayOfWeek.Saturday || n.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("Hurra!!!");
            }
            else
                Console.WriteLine("Grå vardag...");
        }

        static void ReadDateFromUser()
        {
            Console.Write("Ange när du föddes i år-mån-dag ex 2020-01-02:");
            string input = Console.ReadLine();
            //Now what...

            //DateTime.TryParseExact()
            DateTime dt = DateTime.ParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Console.WriteLine($"Det var på en {dt.DayOfWeek}");

        }

        static void DateDiff()
        {
            //Days to christmas
            DateTime datum = DateTime.Now;


            datum = datum.AddDays(148);
            datum = datum.AddDays(-30);




            DateTime christmas = new DateTime(2020,12,24);
            TimeSpan diff = christmas - datum;
            
        }

        static void CreateInvoice()
        {
            var invoiceDatum = DateTime.Now.Date;
            var forfalloDatum = invoiceDatum.AddDays(30).Date;
            if (forfalloDatum.DayOfWeek == DayOfWeek.Sunday)
                forfalloDatum = forfalloDatum.AddDays(1);
            if (forfalloDatum.DayOfWeek == DayOfWeek.Saturday)
                forfalloDatum = forfalloDatum.AddDays(-1);

            //DATUM sista dagen i förra månaden
            var firstThisMonth = new DateTime(invoiceDatum.Year, invoiceDatum.Month,1);
            var lastDateLastMonth = firstThisMonth.AddDays(-1);

            int daysToAdjust = (invoiceDatum.Day);
            lastDateLastMonth = invoiceDatum.AddDays(-daysToAdjust);


            Console.WriteLine($"{invoiceDatum} {forfalloDatum}");
        }

       

        static void DateTimeLista()
        {
            //DateTime []allaDateTimes =new DateTime[antal];
            List<DateTime> allaDateTimes = new List<DateTime>();
            while (true)
            {
                Console.WriteLine("*** Viktiga datum ***");
                Console.WriteLine("1. Lägg till nytt datum");
                Console.WriteLine("2. Skriv ut alla datum");
                Console.WriteLine("3. Skriv ut hutr många datuim det fionns");
                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    if (allaDateTimes.Count > 10)
                    {
                        Console.WriteLine("DU får inte stoppa in fler. Betala extra om mer än 10");
                        continue; 
                    }
                    var input = Console.ReadLine();
                    DateTime dt = DateTime.ParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    allaDateTimes.Add(dt);
                }
                if (choice == "2")
                {
                    foreach(var dt in allaDateTimes)
                    {
                        Console.WriteLine($"{dt}");
                    }
                }
                if (choice == "3")
                {
                    Console.WriteLine($"Det finns {allaDateTimes.Count} i lådan");
                }


            }
            Console.WriteLine("Hejhej");
        }

        static void Main(string[] args)
        {
            HockeyListan();
            //DateTimeLista();
            //CreateInvoice();
            //ReadDateFromUser();
            //SkapaDatumOchSkrivUt();
            //ConstructAnyDate();
            //DateDiff();
        }

        public class Player
        {
            public string Name { get; set; }
            public int JerseyNumber { get; set; }
            public string TeamName { get; set; }
        }

        //public class Team
        //{
        //    public string TeamName { get; set; }
        //    public List<Player> 
        //}


        static void HockeyListan()
        {
            //DateTime []allaDateTimes =new DateTime[antal];
            List<Player> allPlayers = new List<Player>();
            while (true)
            {
                Console.WriteLine("*** Viktiga datum ***");
                Console.WriteLine("1. Lägg till spelare");
                Console.WriteLine("2. Skriv ut alla spelare");
                Console.WriteLine("3. Change player");
                Console.WriteLine("54. Save all players to file");
                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Namn:");
                    var namn = Console.ReadLine();
                    Console.WriteLine("Jersey:");
                    var j = Console.ReadLine();
                    Console.WriteLine("Team:");
                    var t = Console.ReadLine();

                    Player newPlayer = new Player();
                    newPlayer.JerseyNumber = Convert.ToInt32(j);
                    newPlayer.Name = namn;
                    newPlayer.TeamName = t;

                    allPlayers.Add(newPlayer);
                }
                if (choice == "2")
                {
                    foreach (var player in allPlayers)
                    {
                        Console.WriteLine($"{player.Name} has jersey {player.JerseyNumber} and plays for {player.TeamName}");
                    }
                }

            }
        }

    }
}
