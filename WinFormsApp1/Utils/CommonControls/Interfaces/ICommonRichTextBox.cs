using WinFormsApp1.Util.CommonControls.Interfaces;

namespace WinFormsApp1.Utils.CommonControls.Interfaces
{
    public interface ICommonRichTextBox
    {
        string Text { get; set; }
        bool Visible { get; set; }
        bool Enabled { get; set; }
        bool ReadOnly { get; set; }
        int SelectionStart { get; set; }
        void Focus();
    }
    public interface ICommonRichTextBox<T> : ICommonRichTextBox
    {
        T Tag { get; set; }
    }
}
