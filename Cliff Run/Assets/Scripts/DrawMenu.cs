using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class DrawMenu : MonoBehaviour {
    private Vector3 scale;
    public float originalWidth = 640.0f;  // define here the original resolution
    public float originalHeight = 360.0f; // you used to create the GUI contents 
    public float x, y, width, height;
    public float ad;
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        scale.x = Screen.width / originalWidth; // calculate hor scale
        scale.y = Screen.height / originalHeight; // calculate vert scale
        scale.z = 1;
        var svMat = GUI.matrix; // save current matrix
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
        //draw here

        if(GUI.Button(new Rect(339.1f, 396.3f, 148.1f, 48f), "Play"))
        {
            ad = Random.Range(0, 2);
            if (ad == 0)
            {
                StartAds.Show = true;
                Application.LoadLevel("Game");
                if (Advertisement.isShowing)
                {
                    Time.timeScale = 0;
                }
                if (!(Advertisement.isShowing))
                {
                    Time.timeScale = 1;
                }
            }else
            {
                Application.LoadLevel("Game");
            }

        }
        GUI.Button(new Rect(339.1f, 452.52f, 148.1f, 48f), "?");

        //
        GUI.matrix = svMat; // restore matrix

    }
}
