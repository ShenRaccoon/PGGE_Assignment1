using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TPCBase
{
    protected Transform cameraTransform;
    protected Transform playerTransform;

    public float distance;
    public float minDist = 1.0f, maxDist = 5.0f;

    public TPCBase(Transform camera, Transform player)
    {
        cameraTransform = camera;
        playerTransform = player;
    }

    public void RepositionCamera()
    {
        
        Vector3 cameraPos = cameraTransform.position;
        //Debug.Log(cameraPos);
        Vector3 playPos = playerTransform.position;
        //Debug.Log(playPos);
        Vector3 dirPlayerToCamera = (cameraPos - playPos);
        Debug.Log(dirPlayerToCamera);
        RaycastHit hit;

        if (Physics.Raycast(playPos, dirPlayerToCamera, out hit,1))
        {
            distance = Mathf.Clamp(hit.distance, minDist, maxDist);
            cameraTransform.position = hit.point;
        }
        else
        {
            distance = maxDist;
        }
        Debug.Log(distance);
    }

    public abstract void Tick();
}


