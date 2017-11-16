using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// These three using statements are necessary
using codeFirst.Models; // <-- Needed for context object
using Microsoft.EntityFrameworkCore; // <-- needed to include sub models
using System.Linq; // <-- for .ToList & other filtering LINQ functions

namespace codeFirst.Controllers
{
    public class HomeController : Controller
    {
        MyAppContext _context;

        public HomeController(MyAppContext context)
        {
            _context = context;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Team> teams = _context.Teams.Include(team => team.Players).ToList();
            List<Player> players = _context.Players.Include(player => player.Team).ToList();

            List<User> users = _context.Users.Include(u => u.Memberships).ThenInclude(m => m.Group).ToList();
            List<Membership> memberships = _context.Memberships.Include(m => m.User).Include(m => m.Group).ToList();
            List<Group> groups = _context.Groups.Include(g => g.Members).ToList();

            Wrapper model = new Wrapper(players, teams, users, groups, memberships);

            

            return View(model);
        }

        [HttpGet]
        [Route("makeMtoNThings")]
        public IActionResult Make_MtoN_Things()
        {
            // Let's create some objects
            User user1 = new User();
            User user2 = new User();
            Group grp1 = new Group();
            Membership mbr1 = new Membership();
            Membership mbr2 = new Membership();

            grp1.Name = "Coders Group";

            user1.Name = "Inspector Mike";
            user1.Address = "The Dojo";
            user1.City = "Chicago";
            user1.Zip = "60640";

            user2.Name = "Inspector Gadget";
            user2.Address = "Nickelodeon";
            user2.City = "Toronto";
            user2.Zip = "12345";

            mbr1.User = user1;
            mbr1.Group = grp1;

            mbr2.User = user2;
            mbr2.Group = grp1;

            _context.Add(user1);
            _context.Add(user2);
            _context.Add(grp1);
            _context.Add(mbr1);
            _context.Add(mbr2);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("make1toMThings")]
        public IActionResult Make_1toM_Things()
        {
           Player player1 = new Player();
           Player player2 = new Player();

           Team Cubs = new Team();
           Cubs.City = "Chicago";
           Cubs.Name ="Cubs";

           player1.Name = "Ryne Sandberg";
           player1.Team = Cubs;

           player2.Name = "Andre Dawson";
           player2.Team = Cubs;

           _context.Players.Add(player1);
           _context.Players.Add(player2);

           _context.Teams.Add(Cubs);
           
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("addTeam")]
        public IActionResult addTeam(Team newTeam)
        {
            _context.Add(newTeam);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }   

        [HttpPost]
        [Route("addPlayer")]
        public IActionResult addPlayer(Player newPlayer, int TeamId)
        {
            newPlayer.TeamID = TeamId;
            _context.Add(newPlayer);
            _context.SaveChanges(); 
            return RedirectToAction("Index");
        }   

        [HttpGet]
        [Route("delPlayer/{playerId}")]
        public IActionResult delPlayer(int playerId)
        {
            Player pl = _context.Players.Where(p => p.PlayerId == playerId).FirstOrDefault();
            if(pl != null)
            {
                _context.Remove(pl);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
    }
}
