using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float minX = 3.6f;
    float maxX = 18f;
    float minY = 1.5f;
    float maxY = 8;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;
        if (Input.GetKey(KeyCode.A)){
            if(targetX-0.2f > minX){
                targetX -= 0.2f;
            }
        }
        if (Input.GetKey(KeyCode.D)){
            if(targetX+0.2f < maxX){
                targetX += 0.2f;
            }
        }
        if (Input.GetKey(KeyCode.S)){
            if(targetY-0.2f > minY){
                targetY -= 0.2f;
            }
        }
        if (Input.GetKey(KeyCode.W)){
            if(targetY+0.2f < maxY){
                targetY += 0.2f;
            }
        }
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
