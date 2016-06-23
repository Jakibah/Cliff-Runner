using UnityEngine;
using System.Collections;

public class WifiCheck : MonoBehaviour {

    public static AndroidJavaObject AndroidPlugin = null;
    private AndroidJavaObject activityContext = null;

    void Start()
    {
        if (AndroidPlugin == null)
        {
            using (AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
            }
            using (AndroidJavaClass pluginClass = new AndroidJavaClass("com.jakibah.unitywifichecker.AndroidPlugin"))
            {
                if (pluginClass != null)
                {
                    AndroidPlugin = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    AndroidPlugin.Call("setContext", activityContext);
                   

                }
            }
        }
    }
	
	// Update is called once per frame
	public static bool getWifi()
    {
        return AndroidPlugin.Call<bool>("getWifi");
    }
}
