using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static int enemyCounter = 0;
    public EnemySpawner[] spawners;
    public float duration;
	public BoxCollider2D spawnBox;
	public GameObject powerUp;

	private Bounds spawnBounds;
	private int index = 0;
    private float timer = 0;


	private void Awake()
	{
		spawnBounds = spawnBox.bounds;
	}
	void Update()
    {
        timer += Time.deltaTime;

		if (timer > duration)
        {
            timer = 0;
			spawners[index++ % spawners.Length].isSpawn = true;

			float randomX = Random.Range(spawnBounds.min.x, spawnBounds.max.x);
			float randomY = Random.Range(spawnBounds.min.y, spawnBounds.max.y);
			Vector2 randomPoint = new Vector2(randomX, randomY);

			Instantiate(powerUp, randomPoint, Quaternion.identity);
		}

    }
}
