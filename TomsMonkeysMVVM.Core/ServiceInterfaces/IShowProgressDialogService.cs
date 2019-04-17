using System;
using System.Collections.Generic;
using TomsMonkeysMVVM.Core.Enums;
using TomsMonkeysMVVM.Core.Models;

namespace TomsMonkeysMVVM.Core.ServiceInterfaces
{
    public interface IShowProgressDialogService
    {
        void Show();
        void Dissmiss();
    }
}
