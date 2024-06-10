using WinFormsApp1.Services;
using WinFormsApp1.Utils;
using WinFormsApp1.Models;
using Refit;

namespace WinFormsApp1.Views.Login
{
    public class LoginPresenter(IMainService mainService, ICurrentUserService currentUserService)
    {
        private ILoginView _view;
        private readonly IMainService _mainSevice = mainService;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public LoginState State { get; set; } = LoginState.NotAutorized;

        public void SetView(ILoginView view)
        {
            _view = view;
        }
        public async Task Logare()
        {
            _view.ErrorType = FrmLogin.LoginErrorType.None;
            try
            {
                ValidareForm();
                var result = await GetStatusLogare(_view.User, _view.Password);
                ValidareResult(result);

                CloseAutorized();
            }
            catch (ValidationException ex)
            {
                if (ex.Message.ToUpper().Contains("UTILIZATOR"))
                    _view.ErrorType = FrmLogin.LoginErrorType.UserName;
                else if (ex.Message.ToUpper().Contains("PAROLA"))
                    _view.ErrorType = FrmLogin.LoginErrorType.Password;
                else
                    _view.ErrorType = FrmLogin.LoginErrorType.Other;
                _view.Error = ex.Message;
            }
            catch (Exception ex)
            {
                _view.ErrorType = FrmLogin.LoginErrorType.Other;
                _view.Error = ex.Message;
            }
        }
        private void ValidareForm()
        {
            _view.User = _view.User.Trim();
            _view.Password = _view.Password.Trim();

            if (string.IsNullOrEmpty(_view.User))
            {
                _view.ErrorType = FrmLogin.LoginErrorType.UserName;
                throw new ValidationException("Completati numele de utilizator.");
            }
            if (string.IsNullOrEmpty(_view.Password))
            {
                _view.ErrorType = FrmLogin.LoginErrorType.Password;
                throw new ValidationException("Completati parola.");
            }
        }
        private void ValidareResult(ValidateUserOut result)
        {
            if (result.StatusCode != ValidationStatusCode.Success)
            {
                throw new ValidationException(result.Result);
            }
        }
        private async Task<ValidateUserOut> GetStatusLogare(string user, string password)
        {
            LoginOut loginOut = new LoginOut();
            try
            {
                loginOut = await _mainSevice.Login(user, password);

                if (loginOut.UserData.StatusCode == ValidationStatusCode.Success)
                {
                    if (loginOut.UserData.UserLogin != null)
                    {
                        _currentUserService.UserId = loginOut.UserData.UserLogin.UserId;
                        _currentUserService.UserName = loginOut.UserData.UserLogin.UserName;
                    }
                }
            }
            catch (Exception ex)
            {
                loginOut = new LoginOut() { 
                    UserData = new ValidateUserOut()
                    {
                        UserLogin = null,
                        Result = ex.Message,
                        StatusCode = ValidationStatusCode.Failed
                    }
                };
            }
            return loginOut.UserData;
        }

        public void CloseNotAutorized()
        {
            State = LoginState.NotAutorized;
            _view.Close();
        }

        public void CloseAutorized()
        {
            State = LoginState.Autorized;
            _view.Close();
        }
    }
}
