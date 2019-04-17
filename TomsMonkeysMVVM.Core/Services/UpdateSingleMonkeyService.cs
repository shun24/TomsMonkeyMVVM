using System;
using System.Collections.Generic;
using System.Linq;
using TomsMonkeysMVVM.Core.Models;
using TomsMonkeysMVVM.Core.ServiceInterfaces;

namespace TomsMonkeysMVVM.Core.Services
{
    public class UpdateSingleMonkeyService : IUpdateSingleMonkeyService
    {
        public void UpdateMonkey(Monkey monkey)
        {
            var targetData = DummyDBMonkeyList.MonkeyList.Single(m => m.Id == monkey.Id);
            targetData.Name = monkey.Name;
            targetData.Count = monkey.Count;
            targetData.Sex = monkey.Sex;
        }
    }
}
