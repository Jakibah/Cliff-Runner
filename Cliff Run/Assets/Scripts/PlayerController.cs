using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public CharacterController cc;
    public float forwardspeed;
    public float speed = 1;
    
    public Text debug;
    
    float gravity = 15.0f;
   
    float jumpSpeed = 10.0f;
    private Vector3 movementj = Vector3.zero;
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
            if (cc.isGrounded)
            {
                movementj.y = jumpSpeed;

            }
        movementj.y -= gravity * Time.deltaTime;

        cc.Move(movementj * Time.deltaTime);
    }
}
