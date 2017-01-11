package md5a4379e8f64d398b47e4e9cda2583e84a;


public class RollTypeAct
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
		mono.android.Runtime.register ("DandDWristStats.RollTypeAct, DandDWristStats, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", RollTypeAct.class, __md_methods);
	}


	public RollTypeAct () throws java.lang.Throwable
	{
		super ();
		if (getClass () == RollTypeAct.class)
			mono.android.TypeManager.Activate ("DandDWristStats.RollTypeAct, DandDWristStats, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
