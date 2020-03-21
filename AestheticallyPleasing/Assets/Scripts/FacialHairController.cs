using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialHairController : MonoBehaviour {

    public bool creamed = false;

    public void ApplyShavingCream()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        creamed = true;
    }
    public void RemoveShavingCream()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        creamed = false;
    }
}
