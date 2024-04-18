using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EnnemySpawnManager : MonoBehaviour
{

    public GameObject player;

    public float spawnTime = 0.5f;

    public GameObject monster;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnMonster", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnMonster() {

        if (gameManager.IsNotPlaying()) {
            return;
        }

        Vector3 playerPosition = player.transform.position;
        float limitY = -1;
        float limitArea = 3;
        float safeArea = 1;
        Vector3 spawnPosition = new Vector3(
            GetRandomCoordinate(playerPosition.x - limitArea, playerPosition.x + limitArea, safeArea),
            GetRandomCoordinate(limitY, 2, 0),
            GetRandomCoordinate(playerPosition.z - limitArea, playerPosition.z + limitArea, safeArea)
        );
        Instantiate(monster, spawnPosition, Quaternion.identity);
    }

    private float GetRandomCoordinate(float min, float max, float safeArea)
    {
        float value = Random.Range(min, max);

        while (value >= -1 * safeArea && value < safeArea)
        {
            value = Random.Range(min, max);
        }

        return value;
    }
}