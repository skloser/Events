using Events.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Model.ViewModels
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
            return user;
        }
    }
}
