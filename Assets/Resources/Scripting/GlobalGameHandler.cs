using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalGameHandler : MonoBehaviour
{
    public bool isDead = false;
    public static GlobalGameHandler gameHandler;
    public GameObject gameOverScreen;

    private void Awake()
    {
        if (gameHandler == null)
        {
            DontDestroyOnLoad(gameObject);
            gameHandler = GetComponent<GlobalGameHandler>();
        }
        else if (gameHandler != this) Destroy(gameObject);
    }

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 4;
        
    }

    // Update is called once per frame
    void Update()
    {
        assignGameOverScreenIfNull();
        checkIfPlayerDied();
        showGameOverIfDead();
        
    }

    public void buttonExitGame()
    {
        Application.Quit();
    }

    public void buttonRetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void assignGameOverScreenIfNull()
    {
        if (gameOverScreen != null) return;
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        if(buildIndex == 3 || buildIndex == 4 || buildIndex == 6 || buildIndex == 7 || buildIndex == 9)
        {
            gameOverScreen = GameObject.Find("GameOverScreen");
        }
    }

    private void enableGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    private void showGameOverIfDead()
    {
        if (isDead) enableGameOver();
    }

    private void checkIfPlayerDied()
    {
        if (health == 0 || health < 0) isDead = true;
    }
}
