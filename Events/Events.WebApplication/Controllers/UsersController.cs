using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Events.WebApplication.Models;
using Events.Model;
using System.Threading.Tasks;
using Events.Data;

namespace Events.WebApplication.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [Authorize]
        public ActionResult MyProfile()
        {
            User userInfo = new User();
            var userVM = new UserViewModel();
            using (var context = new EventsDbContext())
            {

                //userInfo = data.Users.GetUserInfo(User.Identity.Name);
                userInfo = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                userVM = ViewModelMapper.MapUserToUserViewModel(userInfo, userVM);
            }
            return View("MyProfile", userVM);
        }

        public async Task<ActionResult> UpdateProfileAsync(UserViewModel userViewModel)
        {
            await Task.Run(() => UpdateProfile(userViewModel));
            return Redirect("http://localhost:15716/Users/MyProfile");
        }

        [Authorize]
        public ActionResult UpdateProfile(UserViewModel userViewModel)
        {
            var userUpdated = new User();
            using (var context = new EventsDbContext())
            {
                var currentUser = context.Users.Find(userViewModel.Id);
                userUpdated = ViewModelMapper.MapUserViewModelToUser(currentUser, userViewModel);

                context.Entry(userUpdated).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return Redirect("http://localhost:15716/Users/MyProfile");
        }

        [Authorize]
        public ActionResult UserProfile(string username = "orhan")
        {
            var userInfo = new User();
            var userVM = new UserViewModel();
            using (var context = new EventsDbContext())
            {
                userInfo = context.Users.Where(u => u.UserName == username).FirstOrDefault();
                userVM = ViewModelMapper.MapUserToUserViewModel(userInfo, userVM);
            }
            return View("Profile", userVM);
        }
        
        [Authorize]
        public JsonResult Subscribe(string id)
        {

            using (var context = new EventsDbContext())
            {
                var currentUser = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                var userToSubscribeTo = context.Users.Find(id);
                userToSubscribeTo.Followers.Add(currentUser);
                currentUser.Following.Add(userToSubscribeTo);
                context.Entry(currentUser).State = System.Data.Entity.EntityState.Modified;
                context.Entry(userToSubscribeTo).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return Json(new { Operation = "successful" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Unsubscribe(string id)
        {

            using (var context = new EventsDbContext())
            {
                var currentUser = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                var userToUnSubscribeTo = context.Users.Find(id);
                userToUnSubscribeTo.Followers.Remove(currentUser);
                currentUser.Following.Remove(userToUnSubscribeTo);
                context.Entry(currentUser).State = System.Data.Entity.EntityState.Modified;
                context.Entry(userToUnSubscribeTo).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return Json(new { Operation = "successful" }, JsonRequestBehavior.AllowGet);
        }
    }
}