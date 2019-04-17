using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using TomsMonkeysMVVM.Core.Enums;
using TomsMonkeysMVVM.Core.Models;
using TomsMonkeysMVVM.Core.ServiceInterfaces;

namespace TomsMonkeysMVVM.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public MainViewModel(IGetMonkeyListService getMonkeyListService, IShowConfirmDialogService confirmDialogService, IMvxNavigationService navigationService)
        {
            _getGetMonkeyListService = getMonkeyListService;
            _confirmDialogService = confirmDialogService;
            _navigationService = navigationService;
        }


        private readonly IMvxNavigationService _navigationService;
        private readonly IGetMonkeyListService _getGetMonkeyListService;
        private readonly IShowConfirmDialogService _confirmDialogService;

        private int _selectedIndex = -1;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { SetProperty(ref _selectedIndex, value); }
        }

        private Monkey _selectedMonkey;
        public Monkey SelectedMonkey
        {
            get { return _selectedMonkey; }
            set { SetProperty(ref _selectedMonkey, value); }
        }

        private MvxObservableCollection<Monkey> _monkeyList;
        public MvxObservableCollection<Monkey> MonkeyList
        {
            get { return _monkeyList; }
            set { SetProperty(ref _monkeyList, value); }
        }

        public List<Thing> SexItems { get; set; } = new List<Thing>()
            {
                new Thing(Sex.NotSelected),
                new Thing(Sex.Male),
                new Thing(Sex.Female),
            };


        private Thing _selectedSex = new Thing(Sex.NotSelected);
        public Thing SelectedSex
        {
            get { return _selectedSex; }
            set
            {
                if (SetProperty(ref _selectedSex, value))
                {
                    MonkeyList = GetMonkeyList();
                    SelectedIndex = -1;
                };
            }
        }

        public override Task Initialize()
        {
            _monkeyList = GetMonkeyList();

            return base.Initialize();
        }

        public IMvxCommand CountUpCommand => new MvxCommand(CountUp);
        private void CountUp()
        {
            SelectedMonkey.Count++;
            SelectedMonkey.Modified = true;
        }

        public IMvxCommand CountUpExecuteCommand => new MvxCommand(Execute);
        private void Execute()
        {
            IUpdateSingleMonkeyService updateSingleMonkeyService = Mvx.Resolve<IUpdateSingleMonkeyService>();
            foreach (var monkey in MonkeyList)
            {
                if (monkey.Modified == false)
                {
                    continue;
                }
                updateSingleMonkeyService.UpdateMonkey(monkey);
            }
        }

        public IMvxCommand GoGoCommand => new MvxCommand(GoGo);
        private void GoGo()
        {
            _navigationService.Navigate<DetailViewModel>();
            //_navigationService.Close(this);
            //_confirmDialogService.Show("タイトル", "メッセージ", OnDialogOK);

        }

        private void OnDialogOK()
        {
            _navigationService.Navigate<DetailViewModel>();
        }


        private MvxObservableCollection<Monkey> GetMonkeyList()
        {
            switch (SelectedSex.Sex)
            {
                case Sex.Male:
                    return new MvxObservableCollection<Monkey>(_getGetMonkeyListService.GetMonkeyesSelectedBySex(Sex.Male));
                case Sex.Female:
                    return
                       new MvxObservableCollection<Monkey>(_getGetMonkeyListService.GetMonkeyesSelectedBySex(Sex.Female));
                default:
                    return new MvxObservableCollection<Monkey>(_getGetMonkeyListService.GetAllMonkeyesList());
            }
        }

        public IMvxCommand<Monkey> ItemSelected => new MvxCommand<Monkey>(OnItemSelected);
        public void OnItemSelected(Monkey selectedMonkey)
        {
            SelectedMonkey = selectedMonkey;
            SelectedIndex = MonkeyList.IndexOf(_selectedMonkey);
        }

        /// <summary>
        /// RadioGroupの要素として使われるクラス。
        /// </summary>
        public class Thing
        {
            public Thing(Sex sex)
            {
                Sex = sex;

                switch (Sex)
                {
                    case Sex.Male:
                        Caption = "♂";
                        break;
                    case Sex.Female:
                        Caption = "♀";
                        break;
                    default:
                        Caption = "両方";
                        break;
                }
            }

            public string Caption { get; private set; }
            public Sex Sex { get; private set; }

            public override string ToString()
            {
                return Caption;
            }

            public override bool Equals(object obj)
            {
                var rhs = obj as Thing;
                if (rhs == null)
                    return false;
                return rhs.Caption == Caption;
            }

            public override int GetHashCode()
            {
                if (Caption == null)
                    return 0;
                return Caption.GetHashCode();
            }
        }
    }
}