using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform aimTransform;

    [SerializeField]
    float minY, maxY;

    [SerializeField]
    Transform lowerGround, ortaZemin;

    Vector2 endPos;
    private void Start()
    {
        endPos = transform.position;
    }
    void Update()
    {
        cameraRestrictorFNC();
        moveTheFloorsFNC();
    }

    void cameraRestrictorFNC()
    {
         transform.position =new Vector3 (aimTransform.position.x, 
          Mathf.Clamp (aimTransform.position.y,minY,maxY),
          transform.position.z);
    }

    void moveTheFloorsFNC()
    {
        Vector2 interveningAmount = new Vector2(transform.position.x - endPos.x, transform.position.y - endPos.y);
        lowerGround.position += new Vector3(interveningAmount.x, interveningAmount.y, 0f);
        ortaZemin.position += new Vector3(interveningAmount.x, interveningAmount.y, 0f)*.5f;

        endPos = transform.position;
    }


}
