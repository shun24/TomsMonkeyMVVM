using System;
using System.Collections.Generic;
using TomsMonkeysMVVM.Core.Enums;
using TomsMonkeysMVVM.Core.Models;

namespace TomsMonkeysMVVM.Core.ServiceInterfaces
{
    public interface IShowConfirmDialogService
    {
        void Show(string title,string message,Action action);
    }
}
