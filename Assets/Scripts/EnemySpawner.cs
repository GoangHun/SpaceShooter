using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public Enemy enemy;
	public Transform middleTransform;
	public Transform targetTransform;
	public bool isSpawn;
	public int spawnCount;
	public float duration;

	private float timer;
	private int count = 1;

	public CinemachineSmoothPath smoothPath;

	void Update()
    {
		if (isSpawn)
		{
			//SpawnEnemy();
			NewSpawnEnemy();
		}
	}

	public void SpawnEnemy()
	{
		timer += Time.deltaTime;
		if (timer > duration)
		{
			timer = 0;
			count++;
			var go = Instantiate(enemy, transform.position, Quaternion.identity);
			go.SpawnPos = transform;
			go.MiddlePos = middleTransform;
			go.TargetPos = targetTransform;
			SpawnManager.enemyCounter++;
		}

		if (count > spawnCount)
		{
			isSpawn = false;
			count = 0;
		}
	}

	public void NewSpawnEnemy()
	{
		timer += Time.deltaTime;
		if (timer > duration)
		{
			timer = 0;
			count++;
			var go = Instantiate(enemy, smoothPath.m_Waypoints[0].position, Quaternion.identity);
			go.path = smoothPath;
			SpawnManager.enemyCounter++;
		}

		if (count > spawnCount)
		{
			isSpawn = false;
			count = 0;
		}
	}



}
