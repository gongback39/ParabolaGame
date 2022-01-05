using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float patrolDistance;
	public bool facingRight = true;	

	public float speed = 10f;
	public Vector2 dir;

	Rigidbody2D rigid;
	Animator anim;

    public LayerMask enemyMask;
	public Animator muzzleFlash;

	[Header("weapon")]
	public float shootingRange = 10f;
	public float shotDelay = 2.0f;
	public int attackDamage;
	public float bulletSpeed;
	public float timeToLive;
	public Transform firePos;


	float startPos;
	bool canAttack = true; //발사가능
	bool spotEnemy = false; //적발견
	bool isdead = false;
    float HP = 3;

	void Awake(){
		rigid = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Start () {
		startPos = transform.position.x; //좌우로만 움직임.
		dir = transform.right; //오른쪽 방향으로 움직임.
	}

	void Update () {
		if (isdead)
			return;
		if (Mathf.Abs (transform.position.x - startPos) >= patrolDistance) {
			//패트롤 거리만큼 이동했다면 턴
			dir *= -1;
			startPos = transform.position.x;
		}
		if ((facingRight && dir.x < 0) || (!facingRight && dir.x > 0)) {
			Flip ();
		}
		anim.SetFloat ("xSpeed", Mathf.Abs (dir.x));

	}
	void FixedUpdate(){
		rigid.velocity = new Vector2 (dir.x * speed, rigid.velocity.y);
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
    
    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "bullet"){
            anim.SetTrigger ("hurt");
            HP -= 1;
            if (HP == 0){
                anim.SetTrigger("deadTrigger");
            }
        }
    }

    public void SetDestroy(){
		Destroy (gameObject);
	}

}
