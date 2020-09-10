using System;
using System.Globalization;

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

        static void Main(string[] args)
        {
            CreateInvoice();
            //ReadDateFromUser();
            //SkapaDatumOchSkrivUt();
            //ConstructAnyDate();
            //DateDiff();
        }
    }
}
