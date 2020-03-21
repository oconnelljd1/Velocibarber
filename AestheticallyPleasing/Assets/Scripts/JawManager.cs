using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawManager : MonoBehaviour
{

    AudioClip microphoneInput;
    bool microphoneInitialized;
    public float sensitivity = 0.6f;
    public bool flapped;
    public float micLevel;
    public float minLevel = 101.394f;
    public float maxLevel = 131.56f;
    public float smoothTime = 0.01f;
    float target;
    float smoothBoy;
    public float maximumSpeed = 300;

    private void Awake()
    {
        //init microphone input
        if (Microphone.devices.Length > 0)
        {
            microphoneInput = Microphone.Start(Microphone.devices[0], true, 999, 44100);
            microphoneInitialized = true;
        }
    }
    // Use this for initialization
    void Start()
    {
       
    }

    void Flap()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get mic volume
        int dec = 128;
        float[] waveData = new float[dec];
        int micPosition = Microphone.GetPosition(null) - (dec + 1); // null means the first microphone
        microphoneInput.GetData(waveData, micPosition);

        // Getting a peak on the last 128 samples
        float levelMax = 0;
        for (int i = 0; i < dec; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        float level = Mathf.Sqrt(Mathf.Sqrt(levelMax));

        
        
        micLevel = level;
        float bigBoy = Mathf.Lerp(minLevel, maxLevel, level);

        if (level < sensitivity)
        {
            bigBoy = minLevel;
        }

        transform.localEulerAngles = new Vector3(0, Mathf.SmoothDamp(current:transform.localEulerAngles.y, target:bigBoy, currentVelocity:ref smoothBoy, smoothTime:smoothTime, deltaTime:Time.deltaTime,maxSpeed:maximumSpeed), 0);
    }

}
