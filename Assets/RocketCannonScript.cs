using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCannonScript : MonoBehaviour
{
    public float deg; //각도
    public float rad;
    public float turretSpeed; //포신 스피이드
    public GameObject turret;
    public GameObject line;
    public Transform T_turret;
    public GameObject Bullet;
    public float startAimTime;
    public bool charm = false;
    public bool endAimTime = false;
    public float whileAimTime = 0;
    public float turretRotX;
    public float turretRotY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)){
            deg = deg+Time.deltaTime*turretSpeed;
            rad = deg*Mathf.Deg2Rad;
            turret.transform.localPosition = new Vector2(1.5f*Mathf.Cos(rad), 1.5f*Mathf.Sin(rad));
            turret.transform.eulerAngles = new Vector3(0,0,deg);
            line.transform.localPosition = new Vector2(1.5f*Mathf.Cos(rad), 1.5f*Mathf.Sin(rad));
            //line.transform.eulerAngles = new Vector3(0,0,deg);
            turretRotX = Mathf.Cos(rad)/1.5f;
            turretRotY = Mathf.Sin(rad)/1.5f;
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            deg = deg-Time.deltaTime*turretSpeed;
            rad = deg*Mathf.Deg2Rad;
            turret.transform.localPosition = new Vector2(1.5f*Mathf.Cos(rad), 1.5f*Mathf.Sin(rad));
            turret.transform.eulerAngles = new Vector3(0,0,deg);
            line.transform.localPosition = new Vector2(1.5f*Mathf.Cos(rad), 1.5f*Mathf.Sin(rad));
            //line.transform.eulerAngles = new Vector3(0,0,deg);
            turretRotX = Mathf.Cos(rad)/1.5f;
            turretRotY = Mathf.Sin(rad)/1.5f;
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            endAimTime = false;
            charm = true;
            startAimTime = Time.time;
        }
        if(Input.GetKey(KeyCode.Space)){
            whileAimTime = Time.time - startAimTime;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            GameObject go = Instantiate(Bullet, T_turret.position, T_turret.rotation);
            endAimTime = true;
            charm = false;
        }
    }
}


//GameObject go = Instantiate(Bullet, T_turret.position, T_turret.rotation);