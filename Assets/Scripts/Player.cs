using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int life = 5;

    public int score = 0;

    public GameObject lifeText;

    public GameObject scoreText;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        life -= damage;
        lifeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Life: " + life;
        gameManager.UpdateGameState();
    }

    public void AddScorePoints(int points)
    {
        score += points;
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
    }
}
