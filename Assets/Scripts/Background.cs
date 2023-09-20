using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Background : MonoBehaviour
{
    public float speed1;
	public float speed2;

	public Transform nebula1;
    public Transform nebula2;
	public Transform stars1;
	public Transform stars2;
	public Transform stars3;
	public Transform stars4;
	public Transform planet1;
	public Transform planet2;
	public Transform planet3;
	public BoxCollider2D spawnBox;

	private Bounds spawnBounds;
	private float bgHeight;

    private void Awake()
    {
		bgHeight = nebula1.gameObject.GetComponent<Renderer>().bounds.size.y;
		spawnBounds = spawnBox.bounds;
	}

    public void OnTriggerExit2D(Collider2D collision)
    {
        var target = collision.transform;
        if (collision.CompareTag("Background"))
        {
            var pos = new Vector3(0, bgHeight * 2, 0);
            target.position += pos;
        }
		else if (collision.CompareTag("Planet"))
		{
			float randomX = Random.Range(spawnBounds.min.x, spawnBounds.max.x);
			float randomY = Random.Range(spawnBounds.min.y, spawnBounds.max.y);
			Vector2 randomPoint = new Vector2(randomX, randomY);
			target.position = randomPoint;
		}
	}

    void Update()
    {
		nebula1.position += Vector3.down * speed1 * Time.deltaTime;
		nebula2.position += Vector3.down * speed1 * Time.deltaTime;
		stars1.position += Vector3.down * speed2 * Time.deltaTime;
		stars2.position += Vector3.down * speed2 * Time.deltaTime;
		stars3.position += Vector3.down * speed1 * Time.deltaTime;
		stars4.position += Vector3.down * speed1 * Time.deltaTime;
		planet1.position += Vector3.down * speed2 * Time.deltaTime;
		planet2.position += Vector3.down * speed2 * Time.deltaTime;
		planet3.position += Vector3.down * speed2 * Time.deltaTime;
	}
}
