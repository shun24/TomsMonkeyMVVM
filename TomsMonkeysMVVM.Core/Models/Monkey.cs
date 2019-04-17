using System;
using MvvmCross.Core.ViewModels;

namespace TomsMonkeysMVVM.Core.Models
{
    public class Monkey: MvxNotifyPropertyChanged
    {
        public Monkey()
        {
        }

        private int _id;

        private string _name;

        private int _count;

        private int _sex;

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public int Count
        {
            get { return _count; }
            set { SetProperty(ref _count, value); }
        }

        public int Sex
        {
            get { return _sex; }
            set { SetProperty(ref _sex, value); }
        }

        public bool Modified { get; set; } = false;
    }
}
