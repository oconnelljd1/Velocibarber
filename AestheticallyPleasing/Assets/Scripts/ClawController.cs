using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{

    private SteamVR_Controller.Device device;
    private SphereCollider sphereCollider;

    // Use this for initialization
    void Start ()
    {
        device = SteamVR_Controller.Input((int)GetComponentInParent<SteamVR_TrackedObject>().index);
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Bell")
        {
            other.GetComponent<AudioSource>().Play();
            StartCoroutine("FinishCoroutine");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (device.GetHairTriggerDown())
        {
            sphereCollider.enabled = true;
        }
        else if (device.GetHairTriggerUp())
        {
            sphereCollider.enabled = false;
        }
    }

    private IEnumerator FinishCoroutine()
    {
        yield return new WaitForSeconds(1);
        GameController.instance.NewGame();
    }

    public bool GetTrigger()
    {
        return device.GetHairTrigger();
    }
}
