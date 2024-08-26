using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public bool CursorEnabled
    {
        set
        {
            Cursor.visible = value;
            if (value)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreDisplay(0);
    }

    public void UpdateScoreDisplay(int score)
    {
        scoreText.text = "Score: " + score;
    }

}