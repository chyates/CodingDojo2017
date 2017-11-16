using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var foundArtist = from person in Artists
                              where person.Hometown == "Mount Vernon"
                              select new {person.ArtistName, person.Age};
            foreach (var artist in foundArtist)
            {
                Console.WriteLine($"Mount Vernon: {artist.ArtistName}" + "-" + $"{artist.Age}");
            }

            //Who is the youngest artist in our collection of artists?
            var youngestArtist = Artists.OrderBy(person => person.Age).Take(1);
            foreach (var artist in youngestArtist)
            {
                Console.WriteLine($"Youngest artist: {artist.ArtistName}"+ "-" + $"{artist.Age}");
            }

            //Display all artists with 'William' somewhere in their real name
            var allWilliams = Artists.Where(person => person.RealName.Contains("William"));

            foreach (var william in allWilliams)
            {
                Console.WriteLine($"William: {william.ArtistName}");
            }

            //Display the 3 oldest artist from Atlanta
            var threeOldest = Artists.OrderByDescending(person => person.Age).Where(person => person.Hometown == "Atlanta").Take(3);

            foreach (var artist in threeOldest)
            {
                Console.WriteLine($"Old Atlantean: {artist.ArtistName}");
            }

            // (Optional) Display the Group Name of all groups that have members that are not from New York City

            // 1: var declaration equal to first collection
            var notNYC = Artists
            // 2: 1st argument: 2nd collection to deal with ("Groups"); 2nd argument: lambda w/ 1st group value to compare-->Artists selects artist.GroupId as the combination value; 3rd argument: lambda w/ 2nd group value to compare-->Group selects Group.Id as combo value; 4th argument: lambda that  defines how values are combined-->artist.GroupId joins the Groups table on Group.Id
            
            // 3: return the artist that now contains all the group information
            .Join(Groups, artist =>artist.GroupId, group => group.Id, (artist, group) => { artist.Group = group; return artist; })
            // 4: Filter newly created artist info where each artist.Hometown doesn't equal NYC AND where each artist is part of a group
            .Where(artist => artist.Hometown != "New York City" && artist.Group != null)
            // 5: Instead of giving me artist objects, give me the name of the group that each artist belongs to
            .Select(artist => artist.Group.GroupName)
            // 6: Since groups have multiple members, only return distinct group names (ie. don't give me "Backstreet Boys" for each BSB member)
            .Distinct()
            // 7: Turn it into a list so it can be iterated over
            .ToList();

            // 8: Iterate over that list
            foreach (var group in notNYC)
            {
                Console.WriteLine($"Non-NYC based group: {group}");
            }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            var wuTangMembers = Groups
            .Where(group => group.GroupName == "Wu-Tang Clan")
            .GroupJoin(Artists, group => group.Id, artist => artist.GroupId, (group, artists) => {group.Members = artists.ToList(); return group;})
            .Single();

            foreach (var artist in wuTangMembers.Members)
            {
                Console.WriteLine($"Wu-Tang Member: {artist.ArtistName}");
            }
        }
    }
}
