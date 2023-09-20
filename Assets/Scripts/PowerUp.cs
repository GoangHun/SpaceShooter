using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	public int speed;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<Player>().LazerLevelUp();
			Destroy(gameObject);
		}
	}
	void Update()
    {
		transform.position += Vector3.down * speed * Time.deltaTime;
	}
}
