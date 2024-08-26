using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int lives = 1;
    [SerializeField] private float timeLimit = 60f;

    private int currentScore = 0;

    private float levelTimer = -1f;
    private PlayerController player;
    private GameHUD hud;
    public GameOverScreen gameOverScreen;
    private void Awake()
    {
        player = FindAnyObjectByType<PlayerController>();
        hud = FindObjectOfType<GameHUD>();
    }


    // Start is called before the first frame update
    void Start()
    {
        levelTimer = timeLimit;


    }

    // Update is called once per frame
    void Update()
    {
        if (levelTimer > 0)
        {
            levelTimer -= Time.deltaTime;
            if (levelTimer <= 0)
            {
                GameOver();  
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void GameOver()
    {
        gameOverScreen.Setup(currentScore);
        Debug.Log("Game Over");
        levelTimer = -1;
        player.CanMove = false;
    }

    public void LevelComplete()
    {
        Debug.Log("Level Completed");
        levelTimer = -1;
        player.CanMove = false;
    }

    public void ModifyScore(int amount)
    {
        currentScore += amount;
        if (currentScore < 0)
        {
            currentScore = 0;
        }
        hud.UpdateScoreDisplay(currentScore);
        Debug.Log("Current Score: " + currentScore);
    }

    public bool SubtractLife(Collider other,Transform checkpoints)
    {
        if (lives > 0)
        {
            other.TryGetComponent(out PlayerController controller);
            controller.TeleportToPosition(checkpoints.position);
            lives--;
            Debug.Log("Lives Left: " + lives);
            return true;
        }
        else
        {
            GameOver();
            return false;
        }
    }


} 
