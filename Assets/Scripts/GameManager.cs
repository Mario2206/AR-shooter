using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public enum GameState { Playing, EndGame }

    private Player player;

    private GameObject endUi;

    private GameObject gameUi;

    public GameObject scoreText;

    [SerializeField]
    public GameState gameState;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>();
        endUi = GameObject.FindGameObjectWithTag("EndUi");
        gameUi = GameObject.FindGameObjectWithTag("GameUi");

        endUi.SetActive(false);
        gameState = GameState.Playing;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateGameState()
    {
        if (player.life <= 0) {
            gameUi.SetActive(false);
            endUi.SetActive(true);
            gameState = GameState.EndGame;
            scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + player.score;
        }

        else if(player.life > 0 && gameState == GameState.EndGame)
        {
            gameUi.SetActive(true);
            endUi.SetActive(false);
            gameState = GameState.Playing;
        }
    }

    public bool IsNotPlaying()
    {
        return gameState != GameState.Playing;
    }
}
