using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float xMargin = 2f;      // 카메라가 움직임을 시작하는 거리 X.
	public float yMargin = 2f;      // 카메라가 움직임을 시작하는 거리 Y.
	public float xSmooth = 2f;      // 카메라의 움직임의 부드러움 정도. 값이 작을 수록 부드럽게 움직인다.X
	public float ySmooth = 2f;      // 카메라의 움직임의 부드러움 정도. 값이 작을 수록 부드럽게 움직인다.Y
	public Vector2 maxXAndY;        // 카메라가 가질 수 있는 최대 X, Y 값.
	public Vector2 minXAndY;        // 카메라가 가질 수 있는 최소 X, Y 값.


	public Transform player;       // 따라다닐 플레이어.

	BulletScript bulletScript;
	RocketCannonScript rocketCannon;
	bool sign = false;


  void start()
  {
		rocketCannon = GameObject.Find("rocketCannon").GetComponent<RocketCannonScript>();
  }

	bool CheckXMargin()
	{
		// 플레이어 위치와 카메라 x위치가 마진 값을 벗어났는지를 체크.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}
	
	bool CheckYMargin()
	{
		// 플레이어 위치와 카메라 y위치가 마진 값을 벗어났는지를 체크.
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}

	void FixedUpdate ()
	{
		rocketCannon = GameObject.Find("rocketCannon").GetComponent<RocketCannonScript>();
		sign = rocketCannon.endAimTime;
		if (sign){
			Debug.Log("0");
			TrackPlayer();
		}
	}

	void TrackPlayer ()
	{	
		bulletScript = GameObject.Find("Bullet").GetComponent<BulletScript>();
		player = bulletScript.transform;
		// 이동할 위치.
		float targetX = transform.position.x;
		float targetY = transform.position.y;
		
		// x마진 이상 움직였다면 이동할 위치 조정.{
		if(CheckXMargin()){
			Debug.Log("0");
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
		}
		// y마진 이상 움직였다면 이동할 위치 조정.
		if(CheckYMargin())
			targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
		
		// 카메라는 일정 값 이상 움직일 수 없다.
		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);
		
		// 카메라 포지션을 설정하기.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
		sign = false;
	}
}
