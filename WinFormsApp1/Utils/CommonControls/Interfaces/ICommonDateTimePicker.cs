﻿namespace WinFormsApp1.Util.CommonControls.Interfaces
{
    public interface ICommonDateTimePicker
    {
        bool Checked { get; set; }
        bool Enabled { get; set; }
        bool Visible { get; set; }
        DateTime Value { get; set; }
    }

    public interface ICommonDateTimePicker<T> : ICommonDateTimePicker
    {
        T Tag { get; set; }
    }
}
