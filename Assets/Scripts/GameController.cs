using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;
    [SerializeField] BeardDetector player;
    private GameObject mannequin;
    private AudioSource audioSource;
    [SerializeField] AudioClip winSFX;
    [SerializeField] AudioClip loseSFX;

	// Use this for initialization
	void Awake ()
    {
	    if(instance)
        {
            Object.Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
	}

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        NewGame();
    }

    public IEnumerator NewGameRoutine()
    {
         if(mannequin)
        {
            yield return new WaitForEndOfFrame();
            FacialHairController[] hairs = player.GetComponentsInChildren<FacialHairController>(true);
            for(var i = 0; i < hairs.Length; i++)
            {
                hairs[i].gameObject.SetActive(true);
                hairs[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            audioSource.clip = winSFX;
            audioSource.Play();
            mannequin.SetActive(false);
        }
        // reset player beard
        mannequin = transform.GetChild(Random.Range(0, transform.childCount - 1)).gameObject;
        mannequin.SetActive(true);
    }

    public void NewGame()
    {
        StartCoroutine(NewGameRoutine());
    }

    public static bool CheckWin(bool[] playerCut, bool[] referenceCut)
    {
        int correct = 0;
        for (var i = 0; i < referenceCut.Length; i++)
        {
            if (referenceCut[i] == playerCut[i])
            {
                correct++;
            }
            else
            {
                correct--;
            }
        }
        if ((float)correct / (float)referenceCut.Length > 0.75)
        {
            return true;
        }
        return false;
    }
}
