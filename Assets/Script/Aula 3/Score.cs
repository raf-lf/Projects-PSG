using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float nextSpawnDistance;
    public Vector2 positionVariance;
    public GameObject[] obstacles = new GameObject[3];


    private void OnTriggerEnter2D(Collider2D hamburguer)
    {
        if (hamburguer.gameObject.GetComponentInChildren<Birb>())
        {
            Hud.score++;
            Destroy(transform.parent.gameObject, 10);
            Spawn();
            gameObject.SetActive(false);

        }
    }

    void Spawn()
    {
        GameObject newSpawn = Instantiate(obstacles[Random.Range(0, obstacles.Length)]);
        newSpawn.transform.position = new Vector2(transform.position.x + nextSpawnDistance + Random.Range(-positionVariance.x, positionVariance.x), Random.Range(-positionVariance.y, positionVariance.y)) ;

    }
}

