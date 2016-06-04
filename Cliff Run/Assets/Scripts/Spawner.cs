using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            Instantiate(Resources.Load("Chunk"), new Vector3(GetComponentInParent<Transform>().position.x + 14.1f, -1.09f, -5.48f), new Quaternion(0, 0, -540, 0));
        }
    }
}
