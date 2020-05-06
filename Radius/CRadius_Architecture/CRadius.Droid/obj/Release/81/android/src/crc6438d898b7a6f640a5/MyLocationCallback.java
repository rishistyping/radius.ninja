package crc6438d898b7a6f640a5;


public class MyLocationCallback
	extends crc64e95e69e34d869711.LocationCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLocationResult:(Lcom/google/android/gms/location/LocationResult;)V:GetOnLocationResult_Lcom_google_android_gms_location_LocationResult_Handler\n" +
			"";
		mono.android.Runtime.register ("CRadius.Droid.MyLocationCallback, CRadius.Droid", MyLocationCallback.class, __md_methods);
	}


	public MyLocationCallback ()
	{
		super ();
		if (getClass () == MyLocationCallback.class)
			mono.android.TypeManager.Activate ("CRadius.Droid.MyLocationCallback, CRadius.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onLocationResult (com.google.android.gms.location.LocationResult p0)
	{
		n_onLocationResult (p0);
	}

	private native void n_onLocationResult (com.google.android.gms.location.LocationResult p0);

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
