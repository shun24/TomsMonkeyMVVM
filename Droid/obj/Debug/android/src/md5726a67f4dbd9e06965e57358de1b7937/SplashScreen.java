package md5726a67f4dbd9e06965e57358de1b7937;


public class SplashScreen
	extends mvvmcross.droid.views.MvxSplashScreenActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("TomsMonkeysMVVM.Droid.SplashScreen, TomsMonkeysMVVM.Droid", SplashScreen.class, __md_methods);
	}


	public SplashScreen ()
	{
		super ();
		if (getClass () == SplashScreen.class)
			mono.android.TypeManager.Activate ("TomsMonkeysMVVM.Droid.SplashScreen, TomsMonkeysMVVM.Droid", "", this, new java.lang.Object[] {  });
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
