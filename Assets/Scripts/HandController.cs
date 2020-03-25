using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

    [SerializeField]private MenuController menu;
    private SteamVR_TrackedController controller;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    private List<GameObject> tools = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
        menu.gameObject.SetActive(false);
        controller = gameObject.GetComponent<SteamVR_TrackedController>();
        trackedObj = gameObject.GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObj.index);
        foreach (Transform child in transform.GetChild(1))
        {
            tools.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
        tools[0].SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            menu.gameObject.SetActive(true);
            if(Mathf.Abs(device.GetAxis().x) > Mathf.Abs(device.GetAxis().y))
            {
                if(device.GetAxis().x > 0)
                {
                    menu.HighlightEquipment(1);
                }
                else
                {
                    menu.HighlightEquipment(3);
                }
            }
            else if(Mathf.Abs(device.GetAxis().y) > Mathf.Abs(device.GetAxis().x))
            {
                if (device.GetAxis().y > 0)
                {
                    menu.HighlightEquipment(0);
                }
                else
                {
                    menu.HighlightEquipment(2);
                }
            }
            else
            {
                Debug.Log("You are equidistant");
            }
        }
        else if(device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            tools[(int)menu.GetSelected()].SetActive(false);
            menu.SelectHighlighted();
            menu.gameObject.SetActive(false);
            tools[(int)menu.GetSelected()].SetActive(true);
        }
	}
}
