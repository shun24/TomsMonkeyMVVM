//using System;
//using System.Collections.Generic;
//using MvvmCross.Platform;
//using TomsMonkeysMVVM.Core.Models;
//using TomsMonkeysMVVM.Core.ServiceInterfaces;

//namespace TomsMonkeysMVVM.Core.Services
//{
//    public class UpdateMonkeyListService : IUpdateMonkeyListService
//    {
//        public void UpdateList(List<Monkey> monkeyList)
//        {
//            IUpdateSingleMonkeyService updateSingleMonkeyService = Mvx.Resolve<IUpdateSingleMonkeyService>();
//            foreach (var monkey in monkeyList)
//            {
//                if (monkey.Modified == false)
//                {
//                    continue;
//                }
//                updateSingleMonkeyService.UpdateMonkey(monkey);
//            }
//        }
//    }
//}
