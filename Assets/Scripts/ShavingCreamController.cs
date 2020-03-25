using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShavingCreamController : MonoBehaviour {
    
    private SteamVR_Controller.Device device;

    // Use this for initialization
    void Start () {
        device = SteamVR_Controller.Input((int)GetComponentInParent<SteamVR_TrackedObject>().index);
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (device.GetHairTrigger())
        {
            Debug.DrawRay(transform.GetChild(0).position, transform.GetChild(0).forward, Color.blue);
            RaycastHit hit;
            if(Physics.Raycast(transform.GetChild(0).position, transform.GetChild(0).forward, out hit, 1))
            {
                if (hit.collider.tag == "Hair")
                {
                    hit.collider.GetComponent<FacialHairController>().ApplyShavingCream();
                    // hit.collider.GetComponentInChildren<AudioSource>().Play();
                    gameObject.GetComponent<AudioSource>().Play();
                }
            }
        }
	}
}
