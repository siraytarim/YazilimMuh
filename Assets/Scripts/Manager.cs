using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static bool gameOver;
    public static bool isGameStarted;

    public GameObject gameOverPanel;
    public GameObject startingText;

    public static int numberOfCoins;

    public Text coinsText;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        numberOfCoins = 0;
        isGameStarted = true;
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        coinsText.text = "Coins: " + numberOfCoins;

        if (Input.GetMouseButton(0))   // 0 for mouse left button
        {
            isGameStarted = true;
            Destroy(startingText);
        }

    }
}
