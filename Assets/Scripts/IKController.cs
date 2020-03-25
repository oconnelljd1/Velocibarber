using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IKController : MonoBehaviour {

    [SerializeField] float debugValX = 0.9f;
    [SerializeField] float debugValY = 0.9f;
    [SerializeField] float debugValZ = 0.9f;
    [SerializeField] GameObject headset;
    [SerializeField] GameObject head;
    [SerializeField] GameObject rightController;
    [SerializeField] GameObject rightHand;
    GameObject rightElbow;
    GameObject rightShoulder;
    [SerializeField] GameObject leftController;
    [SerializeField] GameObject leftHand;
    GameObject leftElbow;
    GameObject leftShoulder;

    // Use this for initialization
    void Start ()
    {
        rightElbow = rightHand.transform.parent.gameObject;
        rightShoulder = rightElbow.transform.parent.gameObject;
        leftElbow = leftHand.transform.parent.gameObject;
        leftShoulder = leftElbow.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        head.transform.rotation = headset.transform.rotation;
        Vector3 tempPos = headset.transform.position - new Vector3(0, 0, 0.7f * WorldScaler.instance.GetScale());
        tempPos.y = 0;
        transform.position = tempPos;

        rightHand.transform.position = rightController.transform.position;
       // rightHand.transform.rotation = rightController.transform.rotation;
        // rightHand.transform.LookAt(rightController.transform.position);

        rightElbow.transform.position = (rightShoulder.transform.position + rightHand.transform.position) / 2;
       // rightElbow.transform.LookAt(rightHand.transform.position);
       // rightElbow.transform.Rotate(debugValX, debugValY, debugValZ);

        rightShoulder.transform.LookAt(rightController.transform.position);
        // rightShoulder.transform.Rotate(0, 45, 45);

        leftHand.transform.position = leftController.transform.position;
       // leftHand.transform.rotation = leftController.transform.rotation;
        // leftHand.transform.LookAt(leftController.transform.position);

        leftElbow.transform.position = (leftShoulder.transform.position + leftHand.transform.position) / 2;
       // leftElbow.transform.LookAt(leftHand.transform.position);
       //  leftElbow.transform.Rotate(debugValX, debugValY, debugValZ);

        // leftShoulder.transform.LookAt(leftController.transform.position);
       //  leftShoulder.transform.Rotate(0, 45, 45);

        // debugVal, 0, 0
        // 0, debugVal, 0
        // 0, 0, debugVal
    }
}
