using System;
using System.Collections.Generic;
using TomsMonkeysMVVM.Core.Enums;
using TomsMonkeysMVVM.Core.Models;

namespace TomsMonkeysMVVM.Core.ServiceInterfaces
{
    public interface IUpdateSingleMonkeyService
    {
        void UpdateMonkey(Monkey monkey);
    }
}
