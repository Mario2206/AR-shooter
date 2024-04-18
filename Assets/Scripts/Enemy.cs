using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject explosionEffect;

    private GameObject playerCamera;

    private GameManager gameManager;

    private Player player;

    private EnnemySpawnManager enemySpawnManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        player = playerCamera.GetComponent<Player>();
        enemySpawnManager = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnnemySpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsNotPlaying()) return;
        DetectCollisionWithPlayer();
        Move();
    }

    public void OnKill() {
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(explosion, 1.5f);
        player.AddScorePoints(1);
        Debug.Log(enemySpawnManager);
        enemySpawnManager.OnKillMonster();
    }

    private void Move()
    {
        //Vector3 movement = Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0) * new Vector3(hAxis * walkSpeed * Time.deltaTime, 0, vAxis * walkSpeed * Time.deltaTime);
        transform.LookAt(playerCamera.transform.position);
        transform.position += transform.forward* Time.deltaTime* speed;
    }

    private void DetectCollisionWithPlayer()
    {
        float distanceWithPlayer = Vector3.Distance(playerCamera.transform.position, transform.position);
        if (distanceWithPlayer <= 0.1)
        {
            Destroy(gameObject);
            player.Damage(1);
        }
    }
}
