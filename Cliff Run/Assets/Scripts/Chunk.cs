using UnityEngine;
using System.Collections;

public class Chunk : MonoBehaviour
{
    public GameObject THIS;
    public float een, twee, drie, vier;
    
     //Use this for initialization
    void Start()
    {
        een = Random.Range(0, 3);
        twee = Random.Range(0, 3);
        drie = Random.Range(0, 3);
        vier = Random.Range(0, 3);
        THIS = this.gameObject;
        foreach (Transform c in THIS.transform)
        {
            if (c.gameObject.tag == "1")
            {
                if(een >= 1)
                Destroy(c.gameObject);
            }

            if (c.gameObject.tag == "2")
            {
                if(twee >= 1)
                Destroy(c.gameObject);

            }
            if (c.gameObject.tag == "3")
            {
                if(drie >= 1)
                Destroy(c.gameObject);

            }
            if (c.gameObject.tag == "4")
            {
                if(een + twee + drie > 0)
                Destroy(c.gameObject);

            }

        }


    }

     //Update is called once per frame
    void Update()
    {
       
    }
}
