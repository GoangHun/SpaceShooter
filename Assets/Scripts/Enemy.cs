using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
	public int maxHp;
	public float speed;
	public ParticleSystem enemyHitEffect;
	public GameObject smokeParticle;
	public Projectile enemyProjectile;
	public float launchTimeMin;
	public float launchTimeMax;
	public float yOffset;
	private float duration;
	public float moveDuration;
	public CinemachineSmoothPath path;


	private int hp;
	private float timer;
	private float timer2;
	private Rigidbody2D rb2D;
	private float soothPos;

	public Transform SpawnPos { get; set; }
	public Transform MiddlePos { get; set; }
	public Transform TargetPos { get; set; }


	private void Awake()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}
	private void Start()
	{
		hp = maxHp;
		duration = Random.Range(launchTimeMin, launchTimeMax);

		soothPos = 0;
	}

	private void FixedUpdate()
	{
		//timer2 += Time.deltaTime;
		//float t = timer2 / moveDuration;
		//if (t > 1)
		//{
		//	Destroy(gameObject);
		//	SpawnManager.enemyCounter--;
		//}

		//Vector2 enemyPos = CalculateBezierPoint(SpawnPos.position, MiddlePos.position, TargetPos.position, t);
		//rb2D.MovePosition(enemyPos);
		//transform.position = enemyPos;

		soothPos += speed * Time.deltaTime;
		if (soothPos > path.MaxPos)
		{
			Destroy(gameObject);
			SpawnManager.enemyCounter--;
		}
		rb2D.transform.position = path.EvaluateLocalPosition(soothPos);
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (timer > duration)
		{
			timer = 0f;

			var projectile = Instantiate(enemyProjectile, transform.position, Quaternion.identity);
			projectile.Launch(Vector2.down, 10);
		}
	}

	public void OnHit(int damage)
	{
		hp -= damage;
		enemyHitEffect.Play();
		if (hp == 0)
		{
			GameManager.instance.AddScore(1);
			Instantiate(smokeParticle, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	private Vector2 CalculateBezierPoint(Vector2 start, Vector2 passingPos, Vector2 end, float t)
	{

		float u = 1.0f - t;
		float tt = t * t;
		float uu = u * u;
		float uuu = uu * u;
		float ttt = tt * t;

		Vector2 p = uuu * start;
		p += 3 * uu * t * passingPos;
		p += 3 * u * tt * end;
		p += ttt * end;

		return p;
	}
}
