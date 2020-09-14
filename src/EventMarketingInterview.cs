using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EventAndMarkettingCompany
{
    public class Event
    {
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class EmailMarketing
    {
        static void xxxxMain(string[] args)
        {
            var events = new List<Event>{
                new Event{ Name = "Phantom of the Opera", City = "New York"},
                new Event{ Name = "Metallica", City = "Los Angeles"},
                new Event{ Name = "Metallica", City = "New York"},
                new Event{ Name = "Metallica", City = "Boston"},
                new Event{ Name = "LadyGaGa", City = "New York"},
                new Event{ Name = "LadyGaGa", City = "Boston"},
                new Event{ Name = "LadyGaGa", City = "Chicago"},
                new Event{ Name = "LadyGaGa", City = "San Francisco"},
                new Event{ Name = "LadyGaGa", City = "Washington"}
            };

            var customer = new Customer { Name = "John", City = "New York" };


            /*
             * We want you to send an email to this customer with all events in their city
             * Just call AddToEmail(customer, event) for each event you think they should get
             */


            //  foreach(var evt in events){
            //      if (evt.City == customer.City){
            //          AddToEmail(customer, evt);
            //      }
            //  }


            /* close to location */

            /*
            var nearest = events.Select(e => new { distance = GetDistance(customer.City, e.City), ev = e }).OrderBy( e => e.distance).Take(5);

            foreach(var evt in nearest){
                AddToEmail(customer,evt.ev);
            }
            */


            var cheapest = events.Select(e => new { totalPrice = GetDistancePrice(e, customer.City), ev = e }).OrderBy(e => e.totalPrice).Take(5);

            foreach (var evt in cheapest)
            {
                AddToEmail(customer, evt.ev, GetPrice(evt.ev));
            }

            var distanceScore = 0.2;
            var priceScore = 0.8;
            var genreScore = 0.0;

            //var distanceRank = distanceScore * GetDistance(string fromCity, string toCity);
            //var priceRank = priceScore * GetPrice(Event e);
            //var genreRank = genreScore * GetGenre(Event e);





            //var rank = distanceRank + priceRank;
        }

        // You do not need to know how these methods work
        static void AddToEmail(Customer c, Event e, int? price = null)
        {
            var distance = GetDistance(c.City, e.City);
            Console.Out.WriteLine($"{c.Name}: {e.Name} in {e.City}"
                + (distance > 0 ? $" ({distance} miles away)" : "")
                + (price.HasValue ? $" for ${price}" : ""));
        }

        static double GetDistancePrice(Event e, string toCity)
        {

            return (GetDistance(e.City, toCity) * .5) + GetPrice(e);
        }

        static int GetPrice(Event e)
        {
            return (AlphebiticalDistance(e.City, "") + AlphebiticalDistance(e.Name, "")) / 10;
        }

        static int GetDistance(string fromCity, string toCity)
        {
            return AlphebiticalDistance(fromCity, toCity);
        }

        private static int AlphebiticalDistance(string s, string t)
        {
            var result = 0;
            var i = 0;

            for (i = 0; i < Math.Min(s.Length, t.Length); i++)
            {
                // Console.Out.WriteLine($"loop 1 i={i} {s.Length} {t.Length}");
                result += Math.Abs(s[i] - t[i]);
            }

            for (; i < Math.Max(s.Length, t.Length); i++)
            {
                // Console.Out.WriteLine($"loop 2 i={i} {s.Length} {t.Length}");
                result += s.Length > t.Length ? s[i] : t[i];
            }



            return result;
        }
    }
}


 
