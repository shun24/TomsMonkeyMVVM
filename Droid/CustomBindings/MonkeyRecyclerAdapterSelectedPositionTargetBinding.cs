//using System;
//using System.Reflection;
//using MvvmCross.Binding;
//using MvvmCross.Binding.Bindings.Target;
//using MvvmCross.Platform.Platform;
//using TomsMonkeysMVVM.Droid.Views;

//namespace TomsMonkeysMVVM.Droid.CustomBindings
//{
//    public class MonkeyRecyclerAdapterSelectedPositionTargetBinding
//        : MvxPropertyInfoTargetBinding<MonkeyRecyclerAdapter>
//    {
//        // used to figure out whether a subscription to MyPropertyChanged
//        // has been made
//        private bool _subscribed;

//        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWayToSource;

//        public MonkeyRecyclerAdapterSelectedPositionTargetBinding(object target, PropertyInfo targetPropertyInfo)
//            : base(target, targetPropertyInfo)
//        {
//        }

//        // describes how to set MyProperty on MyView
//        protected override void SetValueImpl(object target, object value)
//        {
//            var view = target as MonkeyRecyclerAdapter;
//            if (view == null) return;

//            view.SelectedPosition = (int)value;
//        }

//        // is called when we are ready to listen for change events
//        public override void SubscribeToEvents()
//        {
//            var myView = View;
//            if (myView == null)
//            {
//                MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - MyView is null in MyViewMyPropertyTargetBinding");
//                return;
//            }

//            _subscribed = true;
//            myView.SelectedPositionChanged += HandleMyPropertyChanged;
//        }

//        private void HandleMyPropertyChanged(object sender, EventArgs e)
//        {
//            var myView = View;
//            if (myView == null) return;

//            FireValueChanged(myView.SelectedPosition);
//        }

//        // clean up
//        protected override void Dispose(bool isDisposing)
//        {
//            base.Dispose(isDisposing);

//            if (isDisposing)
//            {
//                var myView = View;
//                if (myView != null && _subscribed)
//                {
//                    myView.SelectedPositionChanged -= HandleMyPropertyChanged;
//                    _subscribed = false;
//                }
//            }
//        }
//    }
//}