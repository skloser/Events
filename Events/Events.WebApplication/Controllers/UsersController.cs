using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Events.Model.ViewModels;
using Events.Data.Repositories;
using Events.Model;
using System.Threading.Tasks;
namespace Events.WebApplication.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [Authorize]
        public ActionResult MyProfile()
        {
            UserViewModel userInfo = new UserViewModel();
            using (IUnitOfWork data = new UnitOfWork(new Data.EventsDbContext()))
            {
                 userInfo = data.Users.GetUserInfo(User.Identity.Name);
            }
                return View("MyProfile",userInfo);
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
            using (IUnitOfWork data = new UnitOfWork(new Data.EventsDbContext()))
            {
              var currentUser = data.Users.GetUser(userViewModel.Id);
                userUpdated = ViewModelMapper.MapUserViewModelToUser(currentUser, userViewModel);
                data.Users.Update(userUpdated);
                data.SaveChanges();
            }
            return Redirect("http://localhost:15716/Users/MyProfile");
        }

        [Authorize]
        public ActionResult UserProfile(string email="orhan@abv.bg")
        {
            var userInfo = new UserViewModel();
            using (IUnitOfWork data = new UnitOfWork(new Data.EventsDbContext()))
            {
                 userInfo = data.Users.GetUserInfo(email);               
            }
            return View("Profile", userInfo);
        }


        //public async Task SubscribeAsync(string id)
        //{
        //    await Task.Run(() => Subscribe(id));
        //}

        [Authorize]
        public JsonResult Subscribe(string id)
        {
           
            using (IUnitOfWork data = new UnitOfWork(new Data.EventsDbContext()))
            {
                var currentUser = data.Users.GetUserByEmail(User.Identity.Name);
                data.Users.GetUser(id).Followers.Add(currentUser);
                data.SaveChanges();
            }
            return Json(new { Operation = "successful" }, JsonRequestBehavior.AllowGet);
        }


        //public async Task UnsubscribeAsync(string id)
        //{
        //    await Task.Run(() => Unsubscribe(id));
        //}

        public JsonResult Unsubscribe(string id)
        {

            using (IUnitOfWork data = new UnitOfWork(new Data.EventsDbContext()))
            {
                var currentUser = data.Users.GetUserByEmail(User.Identity.Name);
                data.Users.GetUser(id).Followers.Remove(currentUser);
                data.SaveChanges();
            }
           return Json(new { Operation = "successful" }, JsonRequestBehavior.AllowGet);
        }
    }
}