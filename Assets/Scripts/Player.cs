using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Camera worldCam;
	private Rigidbody2D playerRigidbody;
	private int lazerLevel = 1;

	public float speed;
	public LayerMask layerMask;
	public Projectile lazer;
	public GameObject hitEffect;
	public ParticleSystem centralGun;
	public ParticleSystem rightGun;
	public ParticleSystem leftGun;

	private void Awake()
	{
		playerRigidbody = GetComponent<Rigidbody2D>();
		worldCam = Camera.main;
	}

	private void FixedUpdate()
	{
		Ray ray = worldCam.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layerMask);

		if (hitInfo)
		{
			Vector2 rayPos = hitInfo.point;
			Vector2 playerPos = playerRigidbody.position;
			var dir = rayPos - playerPos;
			var distance = dir.magnitude;
            if (distance > 0.1)
            {
				dir.Normalize();
				playerPos += dir * speed * Time.deltaTime;
				playerRigidbody.MovePosition(playerPos);
			}
		}
	}

	void Update()
    {
		if (Input.GetButtonDown("Fire1"))
		{
			for (int i = 0; i < lazerLevel; i++)
			{
				Vector3 p = new Vector3();
				Projectile projectile1;
				switch(i % 3)
				{
					case 0:
						p = centralGun.gameObject.transform.position;
						projectile1 = Instantiate(lazer, p, Quaternion.identity);
						projectile1.Launch(Vector2.up, 10);
						break;
					case 1:
						p = rightGun.gameObject.transform.position;
						projectile1 = Instantiate(lazer, p, rightGun.transform.rotation);
						projectile1.Launch(rightGun.transform.up, 10);
						break;
					case 2:
						p = leftGun.gameObject.transform.position;
						projectile1 = Instantiate(lazer, p, leftGun.transform.rotation);
						projectile1.Launch(leftGun.transform.up, 10);
						break;
				}

				
				centralGun.Play();
			}
			
		}
	}

	public void OnHit(int damage)	
	{
		//GameManager.instance.OnPlayerDead();
		//Instantiate(hitEffect, transform.position, Quaternion.identity);
		//Destroy(gameObject);
	}

	public void LazerLevelUp()
	{
		lazerLevel++;
		Debug.Log(lazerLevel);
	}
}
