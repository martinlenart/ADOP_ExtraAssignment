using ADOP_ExtraAssignment.Models;
using ADOP_ExtraAssignment.Services;

namespace ADOP_ExtraAssignment;
class Program
{
    static void Main(string[] args)
    {
        var _randomService = new RandomService();

        //Create 20 random friends
        var _friends = new List<Friend>();
        for (int i = 0; i < 20; i++)
        {
            _friends.Add(Friend.Factory.CreateRandom(_randomService));
        }

        //Write out to Console
        foreach(var friend in _friends)
        {
            Console.WriteLine(friend);
            Console.WriteLine("FavoriteQuotes:");
            foreach (var quote in friend.FavoriteQuotes)
            {
                Console.WriteLine(quote);
            }
            Console.WriteLine();
        }
    }
}

