using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBarScript : MonoBehaviour
{
    RocketCannonScript rocketCannon;
    float nowPotential;
    bool endPotential;
    public RectTransform gauge;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine (FindPlayer());
        rocketCannon = GameObject.Find("rocketCannon").GetComponent<RocketCannonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        nowPotential = rocketCannon.whileAimTime;
        //Debug.Log(nowPotential);
        float ratio = (float)nowPotential/(float)4;
        if (nowPotential > 4){
            gauge.transform.localScale = new Vector3(1, 1,1);
        }
        else{
            gauge.transform.localScale = new Vector3(ratio, 1,1);
        }
        endPotential = rocketCannon.endAimTime;
        if (endPotential){
            //Debug.Log(endPotential);
            gauge.transform.localScale = new Vector3(0, 1,1);
        }
    }
}
