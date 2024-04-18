using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public enum GameState { StartGame, Playing, EndGame }


    private Player player;

    private GameObject endUi;

    private GameObject startUi;

    private GameObject gameUi;

    public GameObject scoreText;

    [SerializeField]
    public GameState gameState;
    [SerializeField] public AudioSource audioSource;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>();
        endUi = GameObject.FindGameObjectWithTag("EndUi");
        startUi = GameObject.FindGameObjectWithTag("StartUi");
        gameUi = GameObject.FindGameObjectWithTag("GameUi");

        gameUi.SetActive(false);
        endUi.SetActive(false);
    }

    public void StartGame()
    {
        audioSource.Play();
        startUi.SetActive(false);
        gameUi.SetActive(true);
        gameState = GameState.Playing;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateGameState()
    {
        if (player.life <= 0) {
            audioSource.volume = 0.10f;
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
