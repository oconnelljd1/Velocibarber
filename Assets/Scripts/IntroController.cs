using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {


    [SerializeField] ClawController leftController;
    [SerializeField] ClawController rightController;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if(rightController.GetTrigger() && leftController.GetTrigger())
        {
            SceneManager.LoadScene("Bobross");
        }
	}
}
