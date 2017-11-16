using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Session;
using csharpWall2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace csharpWall2.Controllers
{
    public class HomeController : Controller
    {
        private WallContext _context;

        public HomeController(WallContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        public IActionResult Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now
                };
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, model.Password);
                _context.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("currentUserId", newUser.UserId);
                HttpContext.Session.SetString("currentFirstName", newUser.FirstName);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(string email, string password)
        {
            User logUser = _context.Users.SingleOrDefault(user => user.Email == email);
            if (logUser == null)
            {
                TempData["EmailError"] = "Invalid email!";
                return RedirectToAction("Index");
            }
            else 
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                if (hasher.VerifyHashedPassword(logUser, logUser.Password, password) != 0)
                {
                  HttpContext.Session.SetInt32("currentUserId", logUser.UserId);
                  HttpContext.Session.SetString("currentUserEmail", logUser.Email);  
                  return RedirectToAction("Dashboard");
                }
                else 
                {
                    TempData["PasswordError"] = "Invalid password";
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        [Route("/dashboard")]
        public IActionResult Dashboard()
        {
            int? userId = HttpContext.Session.GetInt32("currentUserId");
            if (userId == null)
            {
                TempData["UserError"] = "You must be logged in!";
                return RedirectToAction("Index");
            }
            else 
            {
                User currentUser = _context.Users.SingleOrDefault(u => u.UserId == (int)userId);
                List<User> users = _context.Users.Include(user => user.Posts).Include(user => user.Comments).ToList();
                List<Post> posts = _context.Posts.Include(post => post.Comments).ToList();
                List<Comment> comments = _context.Comments.Include(comment => comment.Post).ThenInclude(post => post.User).ToList();

                ViewBag.User = currentUser;
                Wrapper model = new Wrapper(users, posts, comments);
                return View(model);
            }
        }

        [HttpPost]
        [Route("/post")]
        public IActionResult AddPost(PostViewModel model)
        {
            int? currentUserId = HttpContext.Session.GetInt32("currentUserId");
            if (currentUserId == null)
            {
                TempData["UserError"] = "You must be logged in!";
                return RedirectToAction("Index");
            }
            else
            {
                User currentUser = _context.Users.SingleOrDefault(u => u.UserId == (int)currentUserId);
                if (ModelState.IsValid) {
                    Post newPost = new Post
                    {
                        PostText = model.PostText,
                        UserId = currentUser.UserId,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };
                    _context.Add(newPost);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard");
                } else {
                    TempData["PostError"] = "Failed to create post; please try again";
                    return RedirectToAction("Dashboard");
                }
            }
        }

        [HttpPost]
        [Route("/{postId}/comment")]
        public IActionResult AddComment(CommentViewModel model, int postId)
        {
            int? currentUserId = HttpContext.Session.GetInt32("currentUserId");
            if (currentUserId == null)
            {
                TempData["UserError"] = "You must be logged in!";
                return RedirectToAction("Index");
            }
            else
            {
                User currentUser = _context.Users.SingleOrDefault(u => u.UserId == (int)currentUserId);
                Post thisPost = _context.Posts.SingleOrDefault(p => p.PostId == (int)postId);
                if (ModelState.IsValid) {
                    Comment newComment = new Comment
                    {
                        CommentText = model.CommentText,
                        UserId = currentUser.UserId,
                        PostId = thisPost.PostId,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };
                    _context.Add(newComment);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard");
                } else {
                    TempData["CommentError"] = "Failed to create comment; please try again";
                    return RedirectToAction("Dashboard");
                }
            }
        }

        [HttpGet]
        [Route("/post/{postId}/delete")]
        public IActionResult DeleteComment(int postId)
        {
            int? currentUserId = HttpContext.Session.GetInt32("currentUserId");
            if (currentUserId == null)
            {
                TempData["UserError"] = "You must be logged in!";
                return RedirectToAction("Index");
            }
            else {
            Post thisPost = _context.Posts.SingleOrDefault(c => c.PostId == (int)postId);
            _context.Posts.Remove(thisPost);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
            }
        }
    }
}