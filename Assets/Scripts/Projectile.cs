using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int damage;
	public string targetTag;
	private Rigidbody2D rigidbody2d;
	private void Awake()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
		Destroy(gameObject, 5f);
	}
	public void Launch(Vector2 direction, float force)
	{
		rigidbody2d.AddForce(direction * force, ForceMode2D.Impulse);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(targetTag))
		{
			if (targetTag == "Enemy")
				collision.GetComponent<Enemy>().OnHit(damage);
			else
				collision.GetComponent<Player>().OnHit(damage);

			Destroy(gameObject);
		}
	}
}
