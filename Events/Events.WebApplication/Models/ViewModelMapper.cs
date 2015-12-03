using Events.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.WebApplication.Models
{
    public static class ViewModelMapper
    {
        public static User MapUserViewModelToUser(User user, UserViewModel userViewModel)
        {
            user.Email = userViewModel.Email;
            user.FirstName = userViewModel.FirstName;
            user.LastName = userViewModel.LastName;
            user.Address = userViewModel.Address;
            user.PhoneNumber = userViewModel.PhoneNumber;
            user.Id = userViewModel.Id;
            return user;
        }

        public static UserViewModel MapUserToUserViewModel(User user, UserViewModel userViewModel)
        {
            userViewModel.Email = user.Email;
            userViewModel.FirstName = user.FirstName;
            userViewModel.LastName = user.LastName;
            userViewModel.Address = user.Address;
            userViewModel.PhoneNumber = user.PhoneNumber;
            userViewModel.UserName = user.UserName;
            userViewModel.Id = user.Id;
            return userViewModel;
        }
    }
}
