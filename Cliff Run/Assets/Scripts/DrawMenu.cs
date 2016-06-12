using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class DrawMenu : MonoBehaviour {
    private Vector3 scale;
    public float originalWidth = 640.0f;  // define here the original resolution
    public float originalHeight = 360.0f; // you used to create the GUI contents 
    public float x, y, width, height;
    public float ad;
    public bool showed = false;
    public GUIStyle Play;
    public bool initing = false;
    public bool javabool;
    public AndroidJavaClass AJC;
    void Start () {
        AJC = new AndroidJavaClass("com.jakibah.unitywifichecker.AndroidPlugin");
    }
	
	// Update is called once per frame
	void Update () {
        javabool = AJC.Call<bool>("getWifi", javabool);
	}
    void OnGUI()
    {

      
        scale.x = Screen.width / originalWidth; // calculate hor scale
        scale.y = Screen.height / originalHeight; // calculate vert scale
        scale.z = 1;
        var svMat = GUI.matrix; // save current matrix
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
        //draw here
        //if (GUI.Button(new Rect(339.1f, 396.3f, 148.1f, 48f), "", Play))


        if (javabool == false)
        {
            if (GUI.Button(new Rect(339.1f, 396.3f, 148.1f, 48f), "", Play))
                SceneManager.LoadScene("Game");
        }



        if (javabool == true)
        {

            GetComponent<StartAds>().Show = true;
                }
        //
        GUI.matrix = svMat; // restore matrix

    }
  
    }