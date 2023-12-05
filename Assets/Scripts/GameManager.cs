using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI recordText;
    public Button btn;

    float surviveTime;
    bool isGameover;

   public float SurviveTime {
        get => (int)surviveTime;
        set => surviveTime += value;
    }

    public bool IsGameover {
        get => isGameover;
    }

    void Start() {
        surviveTime = 0f;
        isGameover = false;
    }

    void Update() {
        if (isGameover) {
            if(Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void EndGame() {
        isGameover = true;

        gameoverText.gameObject.SetActive(true);
        recordText.gameObject.SetActive(true);
        btn.gameObject.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime) {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best time : " + (int)bestTime;
    }

    public void Quit() {
        Application.Quit();
    }
}
