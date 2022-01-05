using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimZoneScript : MonoBehaviour
{
    LineRenderer line;
    RocketCannonScript rocketCannon;
    public Transform T_turret;
    float potential;
    float bulletSpeed = 100;
    float Force;
    float Velocity;
    float rotX;
    float rotY;
    float moveX;
    float moveY;
    bool end;
    [Range(0,80)]public int trajectoryCount = 35;

    //float lineRen;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {   
        StartCoroutine("ReadyForThrow");
    }

    private IEnumerator ReadyForThrow(){
        rocketCannon = GameObject.Find("rocketCannon").GetComponent<RocketCannonScript>();
        line = gameObject.GetComponent<LineRenderer>();
        Vector3 lineRen = T_turret.position;
        line.SetPosition(0,lineRen);
        end = rocketCannon.endAimTime; 
        while (!end)
        {
            //Debug.Log("s");
            line.positionCount = 0; //다시 그리기 위해 이전에 그렸던 경로 초기화
            line.positionCount = trajectoryCount;
            for (int i = 1; i < trajectoryCount; i++){
                potential = rocketCannon.whileAimTime;
                rotX = rocketCannon.turretRotX;
                rotY = rocketCannon.turretRotY;
                if (potential <= 4){
                    Force = bulletSpeed*potential*2.5f;
                    Velocity = Force / 1 * potential;
                    moveX = lineRen.x+(Velocity*rotX*potential);
                    moveY = lineRen.y+(Velocity*rotY*potential)-1/2*1*potential*potential;
                    lineRen = new Vector3(moveX, moveY, lineRen.z);
                    line.SetPosition(i, lineRen);
                }
                else if (potential> 4){
                    Debug.Log("0");
                    Force = bulletSpeed*4*2.5f;
                    Velocity = Force / 1 * 4;
                    moveX = lineRen.x+(Velocity*rotX*4);
                    moveY = lineRen.y+(Velocity*rotY*4)-1/2*1*4*4;
                    lineRen = new Vector3(moveX, moveY, lineRen.z);
                    line.SetPosition(i, lineRen);
                }
            }
            yield return new WaitForSeconds(0.015f);
            end = rocketCannon.endAimTime;
        }
    }
}
