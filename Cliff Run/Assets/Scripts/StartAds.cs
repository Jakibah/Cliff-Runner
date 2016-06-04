using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class StartAds : MonoBehaviour {
    public static bool Show = false;

	// Use this for initialization
	void Start () {
        Advertisement.Initialize("1077574");
    }
	
	// Update is called once per frame
	void Update () {
        if (Advertisement.IsReady())
        {
            if(Show == true)
            {
                Show = false;
                Advertisement.Show();
            }
        }
	}
}
