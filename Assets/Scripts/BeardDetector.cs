using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeardDetector : MonoBehaviour
{

    int checkHorz = 45;
    int checkVert = 20;

    public GameObject myBeard;

    public float checkDistance = 0.14f;
    
    public LayerMask masktron;

    private void Start()
    {
        // if (ValidateCut(debugPlayerBeard, debugReferenceBeard))
        // {
        //     Debug.Log("YOU WINNER");
        // }
        // else
        // {
        //     Debug.Log("YOU're NOT A WINNAR");
        // }
    }

    public bool[] CheckBeard()
    {
        Vector3 originPos = transform.position + (transform.rotation * new Vector3(0, -0.15f, 0));
        //int successfulHits = 0;
        Debug.Log("The big check: " + checkHorz + ", " + checkVert);

        bool[] returnList = new bool[checkHorz * checkVert];

        for (int i = 0; i < checkHorz; i++)
        {
            for (int v = 0; v < checkVert; v++)
            {
                
                Vector3 checkPos = originPos + transform.rotation * (Quaternion.Euler(0, ((float)i / (float)checkHorz) * 360, 0) * (transform.forward * checkDistance));
                Vector3 yes = transform.rotation * new Vector3(0, (float)((float)v / (float)checkVert) * 0.3f, 0);
                checkPos += yes;
                RaycastHit hit;
                if (Physics.Raycast(origin:checkPos,direction: (-(checkPos - (originPos + yes)).normalized),maxDistance:0.1f,layerMask: masktron, queryTriggerInteraction:QueryTriggerInteraction.Collide,hitInfo:out hit))
                {
                    if (hit.collider.CompareTag("Hair"))
                    {
                        Debug.Log("Hit");
                        returnList[i + v] = true;
                        Debug.DrawRay(checkPos, (-(checkPos - (originPos + yes)).normalized) * 0.1f, Color.green, 12);
                    }
                    else
                    {
                        returnList[i + v] = false;
                        Debug.DrawRay(checkPos, (-(checkPos - (originPos + yes)).normalized) * 0.1f, Color.red, 12);
                    }
                }
                else
                {
                    Debug.Log("No hit");

                    returnList[i + v] = false;
                    Debug.Log((-(checkPos - (originPos + yes)).normalized) * 0.1f);
                    Debug.DrawRay(checkPos, (-(checkPos - (originPos + yes)).normalized) * 0.1f, Color.red, 12);
                }

            }
        }



        return returnList;
    }
}
