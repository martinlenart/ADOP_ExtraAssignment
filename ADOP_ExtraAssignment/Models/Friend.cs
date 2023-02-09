using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

using ADOP_ExtraAssignment.Services;

namespace ADOP_ExtraAssignment.Models
{
    public class Friend
    {
        public Guid FriendID { get; init; } 

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public override string ToString() => $"{FullName} from {City}, {Country} can be reached at {Email}, from {City}";

        public List<GoodQuote> FavoriteQuotes { get; set; }

        public static class Factory
        {
            public static Friend CreateRandom(RandomService rnd)
            {
                var fn = rnd.FirstName;
                var ln = rnd.LastName;
                var country = rnd.Country;

                var _quotes = new List<GoodQuote>();
                var _nrQuotes = rnd.Next(0, 3); //none, 1 or 2 favorite quotes 
                for (int i = 0; i < _nrQuotes; i++)
                    _quotes.Add(rnd.Quote);

                return new Friend
                {
                    FriendID = Guid.NewGuid(),

                    FirstName = fn,
                    LastName = ln,
                    Email = rnd.Email(fn, ln),
                    City = rnd.City(country),
                    Country = country,
                    FavoriteQuotes = _quotes
                 };
            }
        }
    }
}
