using WinFormsApp1.Views;

namespace WinFormsApp1
{
    public interface IMainView { }
    public partial class FrmMain : BaseView, IMainView
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
