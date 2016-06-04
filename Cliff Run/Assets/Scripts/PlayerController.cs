using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public CharacterController cc;
    public float forwardspeed;
    public float speed = 1;
    public float jumpspeed = 2;
    public Text debug;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        cc = GetComponent<CharacterController>();

        forwardspeed = Time.time * speed;

        Vector3 movement = new Vector3(forwardspeed, 0, 0);

        cc.SimpleMove(movement);
        // jump
        if (Input.touchCount > 0)
        {
            debug.text = "Touched";
        }
        {

        }
        
        
	}
}
