using System;
using System.Collections.Generic;
using TomsMonkeysMVVM.Core.Models;

namespace TomsMonkeysMVVM.Core
{
    public static class DummyDBMonkeyList
    {
        public static List<MonkeyRawData> MonkeyList = new List<MonkeyRawData>()
         {
             new MonkeyRawData { Id = 0, Name = "サル吉オス", Count = 2, Sex = 0 },
             new MonkeyRawData { Id = 1, Name = "マヌケザルオス", Count = 1, Sex = 0 },
             new MonkeyRawData { Id = 2, Name = "サル吉メス", Count = 2, Sex = 1 },
             new MonkeyRawData { Id = 3, Name = "マヌケザルメス", Count = 1, Sex = 1 },
           };
    }
}
