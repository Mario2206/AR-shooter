using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.1f;

    private GameObject playerCamera;

    private GameManager gameManager;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        player = playerCamera.GetComponent<Player>();
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
        player.AddScorePoints(1);
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