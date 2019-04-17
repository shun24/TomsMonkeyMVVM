using System;
using System.Collections.Generic;
using System.Linq;
using TomsMonkeysMVVM.Core.Enums;
using TomsMonkeysMVVM.Core.Models;
using TomsMonkeysMVVM.Core.ServiceInterfaces;

namespace TomsMonkeysMVVM.Core.Services
{
    public class GetMonkeyListService : IGetMonkeyListService
    {

        public List<Monkey> GetAllMonkeyesList()
        {
            var listFromDB = DummyDBMonkeyList.MonkeyList;
            var monkeyList = new List<Monkey>();
            foreach (var monkeyRawData in listFromDB)
            {
                var monkey = new Monkey()
                {
                    Id = monkeyRawData.Id,
                    Name = monkeyRawData.Name,
                    Count = monkeyRawData.Count,
                    Sex = monkeyRawData.Sex,
                };
                monkeyList.Add(monkey);
            }

            return monkeyList;
        }

        public List<Monkey> GetMonkeyesSelectedBySex(Sex sex)
        {
            return GetAllMonkeyesList().Where(m => m.Sex == (int)sex).ToList();
        }
    }
}
