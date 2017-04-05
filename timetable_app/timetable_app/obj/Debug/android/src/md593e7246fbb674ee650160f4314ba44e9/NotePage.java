package md593e7246fbb674ee650160f4314ba44e9;


public class NotePage
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("timetable_app.NotePage, timetable_app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", NotePage.class, __md_methods);
	}


	public NotePage () throws java.lang.Throwable
	{
		super ();
		if (getClass () == NotePage.class)
			mono.android.TypeManager.Activate ("timetable_app.NotePage, timetable_app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
