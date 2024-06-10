using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Views.Login;

namespace WinFormsApp1.Views
{
    public partial class FrmLogin : BaseView, ILoginView
    {
        public LoginPresenter Presenter { get; private set; }
        public string User
        {
            get { return this.txtUsername.Text; }
            set { this.txtUsername.Text = value; }
        }
        public string Password
        {
            get { return this.txtPassword.Text; }
            set { this.txtPassword.Text = value; }
        }
        public string Error
        {
            get { return this.lblError.Text; }
            set { this.lblError.Text = value; }
        }
        public enum LoginErrorType
        {
            None,
            UserName,
            Password,
            Other
        }
        public LoginErrorType ErrorType { get; set; }

        public FrmLogin(LoginPresenter presenter)
        {
            Presenter = presenter;
            Presenter.SetView(this);

            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Logare();
        }

        private void btnAnulare_Click(object sender, EventArgs e)
        {
            Presenter.CloseNotAutorized();
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Logare();
            }
            if (e.KeyData == Keys.Escape)
            {
                Presenter.CloseNotAutorized();
            }
        }

        private async void Logare()
        {
            await Presenter.Logare();

            if (ErrorType == LoginErrorType.None)
                return;
            if (ErrorType == LoginErrorType.UserName)
                ActiveControl = txtUsername;
            if (ErrorType == LoginErrorType.Password)
                ActiveControl = txtPassword;
            if (ErrorType == LoginErrorType.Other)
                ActiveControl = txtUsername;
        }
    }
}
