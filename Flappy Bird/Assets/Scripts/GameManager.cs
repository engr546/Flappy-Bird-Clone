using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver { get; set; }

    public static GameManager instance;
    public GameObject gameOverText;
    public Text scoreText;

    int score = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Scored()
    {
        if (IsGameOver)
            return;
        score++;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        IsGameOver = true;
    }

}
