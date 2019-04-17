package md5f225391da97fdf3976e5858a817fbcf7;


public class MonkeyRecyclerAdapter_MonkeyViewHolder
	extends mvvmcross.droid.support.v7.recyclerview.MvxRecyclerViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("TomsMonkeysMVVM.Droid.Views.MonkeyRecyclerAdapter+MonkeyViewHolder, TomsMonkeysMVVM.Droid", MonkeyRecyclerAdapter_MonkeyViewHolder.class, __md_methods);
	}


	public MonkeyRecyclerAdapter_MonkeyViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == MonkeyRecyclerAdapter_MonkeyViewHolder.class)
			mono.android.TypeManager.Activate ("TomsMonkeysMVVM.Droid.Views.MonkeyRecyclerAdapter+MonkeyViewHolder, TomsMonkeysMVVM.Droid", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
