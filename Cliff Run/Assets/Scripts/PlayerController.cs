using UnityEngine;
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
    public float x, y, width, height;



    float gravity = 15.0f;
   
    float jumpSpeed = 10.0f;
    private Vector3 movementj = Vector3.zero;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Highscore = PlayerPrefs.GetFloat("HighScore");
        cc = GetComponent<CharacterController>();

        forwardspeed = Time.time * speed;

        Vector3 movement = new Vector3(forwardspeed, 0, 0);
        cc.SimpleMove(movement);

        // jump
       // if (Input.touchCount > 0)
            if(Input.GetMouseButton(0))
            if (cc.isGrounded)
            {
                movementj.y = jumpSpeed;

            }
        movementj.y -= gravity * Time.deltaTime;

        cc.Move(movementj * Time.deltaTime);
        //score
        if(this.gameObject.transform.position.y < -1)
        {
            if(PlayerPrefs.GetFloat("HighScore") <= score)
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

        GUI.Label(new Rect(250.05f, 75.6f, 317.4f, 21.44f), "Score "+ score.ToString() + "  " + "HighScore " + Highscore.ToString());

        //
        GUI.matrix = svMat;
    }
}
