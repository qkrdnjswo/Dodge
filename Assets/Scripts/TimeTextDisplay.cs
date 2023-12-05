using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeTextDisplay : MonoBehaviour {
    GameManager gameManager;
    TextMeshProUGUI timeText;

    void Start() {
        gameManager = FindObjectOfType<GameManager>();
        timeText = GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate() {
        if (!gameManager.IsGameover) {
            gameManager.SurviveTime = Time.deltaTime;
            //gameManager.SetScore(Time.deltaTime);
            int scoreTime = (int)gameManager.SurviveTime;
            //int scoreTime = gameManager.GetScore();
            timeText.text = "Time : " + scoreTime.ToString();
        }
    }
}
