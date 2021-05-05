using STORE.WEB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.WEB.ApiService.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignIn(SignInViewModelResource signInViewModelResource);
        Task<UserViewModelResource> SignUp(UserViewModelResource userViewModelResource);
        Task<bool> ResetPasswordMail(PasswordResetViewModelResource passwordResetViewModelResource);
        Task<bool> ChangePasswordUser(ChangePasswordModelViewResource changePasswordModelViewResource);
        void LogOut();
    }
}
