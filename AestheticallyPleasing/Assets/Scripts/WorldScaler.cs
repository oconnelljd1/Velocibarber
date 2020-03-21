using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScaler : MonoBehaviour {

    [SerializeField] GameObject headset;
    [SerializeField] GameObject referencePoint;

    public static WorldScaler instance;
    private float scale;
    public float GetScale()
    {
        return scale;
    }

    private void Awake()
    {
        if (instance)
        {
            Object.Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        scale = headset.transform.position.y / referencePoint.transform.position.y;
        transform.localScale = Vector3.one * scale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
