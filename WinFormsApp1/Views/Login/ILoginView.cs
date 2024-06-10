using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Views.Login
{
    public interface ILoginView
    {
        string User { get; set; }
        string Password { get; set; }
        string Error { get; set; }
        FrmLogin.LoginErrorType ErrorType { get; set; }
        void Close();
    }
    public enum LoginState
    {
        NotAutorized,
        Autorized
    }
}
