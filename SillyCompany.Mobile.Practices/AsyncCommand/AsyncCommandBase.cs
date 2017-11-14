﻿// ****************************************************************************
// <author>Stephen Cleary</author>
// <date>04-2014</date>
// <web>https://msdn.microsoft.com/en-us//magazine/dn630647.aspx</web>
// ****************************************************************************

namespace SillyCompany.Mobile.Practices.AsyncCommand
{
    using System;
    using System.Threading.Tasks;

    public abstract class AsyncCommandBase
    {
        public abstract bool CanExecute(object parameter = null);
        
        public abstract Task ExecuteAsync(object parameter);

        public async void Execute(object parameter)
        {
            await this.ExecuteAsync(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}