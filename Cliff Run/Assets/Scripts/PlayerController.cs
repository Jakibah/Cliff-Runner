﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public CharacterController cc;
    public float forwardspeed;
    public float speed = 1;
    public float score = 0;
    public float Highscore;
    private Vector3 scale;
    public float originalWidth = 640.0f;  // define here the original resolution
    public float originalHeight = 360.0f; // you used to create the GUI contents 
    public bool Lost = false;
    public float x, y, width, height;
    public GUIStyle Retry;
    public GUIStyle Score;


    float gravity = 18.0f;
   
    float jumpSpeed = 10.0f;
    private Vector3 movementj = Vector3.zero;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        Highscore = PlayerPrefs.GetFloat("HighScore");
        cc = GetComponent<CharacterController>();

        forwardspeed = 6 + score / 2;

        Vector3 movement = new Vector3(forwardspeed, 0, 0);
        cc.SimpleMove(movement);

        // jump
        float TouchTime = 0;
        float SpaceTime = Time.time - TouchTime;
        Touch touch = Input.touches[0];

        if (touch.phase == TouchPhase.Began)
            TouchTime = Time.time;

        if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            SpaceTime = Time.time - TouchTime;
            if (Time.time - TouchTime <= 0.5)
            {
                gravity = 18f;
            }
            else if (gravity - SpaceTime < 11)
            {
                gravity = 11;

            }
            else { 
                SpaceTime = Time.time - TouchTime;
                gravity = gravity - SpaceTime;

            }
        }




        if (Input.touchCount > 0)
            if (cc.isGrounded)
            {
                movementj.y = jumpSpeed;
                gravity = gravity - Input.GetTouch(0).deltaTime;

                movementj.y -= gravity * Time.deltaTime;

                cc.Move(movementj * Time.deltaTime);
            }
                //score
                if (this.gameObject.transform.position.y < -1)
                {
                    Lost = true;

                    if (PlayerPrefs.GetFloat("HighScore") <= score)
                    {
                        Highscore = score;
                        PlayerPrefs.SetFloat("HighScore", Highscore);

                    

                }
            }
    }
    void OnGUI()
    {
        scale.x = Screen.width / originalWidth; // calculate hor scale
        scale.y = Screen.height / originalHeight; // calculate vert scale
        scale.z = 1;
        var svMat = GUI.matrix; // save current matrix
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

        //draw here
        if(Lost == true)
        {
            GUI.Label(new Rect(267.02f, 49.88f, 0, 0), "Score: " + score.ToString(), Score);
            GUI.Label(new Rect(267.02f, 66.3f, 0, 0), "HighScore: " + Highscore.ToString(), Score);
            if (GUI.Button(new Rect(230.5f, 310.99f, 62.8f, 23.3f), "", Retry))
            {
                Lost = false;
                
                SceneManager.LoadScene("Game");
            }
        }else
        {
            GUI.Label(new Rect(41.34f, 0, 0, 0), "Score: " + score.ToString(), Score);
        }
       

        //
        GUI.matrix = svMat;
    }
}
