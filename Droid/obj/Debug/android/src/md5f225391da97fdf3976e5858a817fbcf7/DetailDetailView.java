package md5f225391da97fdf3976e5858a817fbcf7;


public class DetailDetailView
	extends mvvmcross.droid.views.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TomsMonkeysMVVM.Droid.Views.DetailDetailView, TomsMonkeysMVVM.Droid", DetailDetailView.class, __md_methods);
	}


	public DetailDetailView ()
	{
		super ();
		if (getClass () == DetailDetailView.class)
			mono.android.TypeManager.Activate ("TomsMonkeysMVVM.Droid.Views.DetailDetailView, TomsMonkeysMVVM.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
