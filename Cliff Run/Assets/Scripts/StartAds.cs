using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class StartAds : MonoBehaviour {
    public bool Show = false;
    public string zoneId;

	// Use this for initialization
	void Start () {
        Advertisement.Initialize("1077574");
    }
	
	// Update is called once per frame
	void Update () {
        if (string.IsNullOrEmpty(zoneId)) zoneId = null;
        if (Advertisement.IsReady())
        {
            if(Show == true)
            {
                ShowOptions options = new ShowOptions();
                options.resultCallback = HandleShowResult;

                Show = false;
                Advertisement.Show(zoneId, options);
            }
        }
	}
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                SceneManager.LoadScene("Game");
                break;
            case ShowResult.Skipped:
                SceneManager.LoadScene("Game");
                break;
            case ShowResult.Failed:
                Debug.LogError("Video failed to show.");
                break;
        }
    }
}
