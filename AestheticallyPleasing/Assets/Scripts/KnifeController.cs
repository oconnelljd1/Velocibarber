using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hair")
        {
            if(other.GetComponent<FacialHairController>().creamed)
            {
                other.gameObject.SetActive(false);
            }
            else
            {
                // hurt customer
            }
        }
    }

}
