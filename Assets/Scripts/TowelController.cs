using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowelController : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("HJHKJH");
        if (other.tag == "Hair")
        {
            Debug.Log("HAIRY");
            other.gameObject.GetComponent<FacialHairController>().RemoveShavingCream();
        }
    }
}
