using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitScript : MonoBehaviour
{
    LineRenderer line;
    RocketCannonScript rocketCannon;
    public Transform T_turret;
    float potential;
    bool ischarm = false;
    float velocity;
    float bulletSpeed = 0.8f;
    float velocityX;
    float velocityY;
    float rotX;
    float rotY;
    float moveX;
    float moveY ;
    [Range(0,80)]public int trajectoryCount = 35;
    // Start is called before the first frame update
    void Start()
    {
        rocketCannon = GameObject.Find("rocketCannon").GetComponent<RocketCannonScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ischarm = rocketCannon.charm;
        if(ischarm){
            StartCoroutine("ReadyForThrow");
        }
    }

    private IEnumerator ReadyForThrow(){
        line = gameObject.GetComponent<LineRenderer>();
        Vector3 lineRen = T_turret.position;
        line.positionCount = 0; //다시 그리기 위해 이전에 그렸던 경로 초기화
        moveX = 0;
        moveY = 0;
        line.positionCount = trajectoryCount;
        if (potential <= 4){
            potential = rocketCannon.whileAimTime;
            velocity =  bulletSpeed*potential;
            rotX = rocketCannon.turretRotX;
            rotY = rocketCannon.turretRotY;
            float k = 0;
            for (int i = 0; i < trajectoryCount; i++){
                velocityX = velocity*rotX;
                velocityY = velocity*rotY - 1*k;
                moveX += velocityX*potential;
                moveY += velocityY*potential - 1/2*velocityY*k;
                lineRen = new Vector3(moveX, moveY, lineRen.z);
                line.SetPosition(i, lineRen);
                k += 0.1f;
            }
        }
        else if(potential > 4){
            velocity =  bulletSpeed;
            rotX = rocketCannon.turretRotX;
            rotY = rocketCannon.turretRotY;
            float k = 0;
            for (int i = 0; i < trajectoryCount; i++){
                velocityX = velocity*rotX;
                velocityY = velocity*rotY - 1*k;
                moveX += velocityX*4;
                moveY += velocityY*4 - 1/2*velocityY*k;
                lineRen = new Vector3(moveX, moveY, lineRen.z);
                line.SetPosition(i, lineRen);
                k += 0.1f;
            }
        }
        yield return new WaitForSeconds(0.015f);
    }
}
