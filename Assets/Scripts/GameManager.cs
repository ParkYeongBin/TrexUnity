using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public Text scoreText;
    public Text TopscoreText;
    public GameObject gameoverUI;

    private float score = 0;
    private float highScore = 0;

    private AudioSource pointAudio;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            pointAudio = GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(isGameover)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Main");
            }
        }
        else
        {
            PrintHighScore();

            AddScore(3 + Time.deltaTime * 0.1f);

            if (score % 100 < 0.1 && score >= 100)
                pointAudio.Play();
        }
    }

    public void AddScore(float speed)
    {
        if (!isGameover)
        {
            score += (speed * 0.01f);

            if (score < 10)
                scoreText.text = "HI       0000" + (int)score;
            else if (score < 100)
                scoreText.text = "HI       000" + (int)score;
            else if (score < 1000)
                scoreText.text = "HI       00" + (int)score;
            else if (score < 10000)
                scoreText.text = "HI       0" + (int)score;
            else
                scoreText.text = "HI       " + (int)score;
        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;

        gameoverUI.SetActive(true);

        highScore = PlayerPrefs.GetFloat("TOPSCORE");

        if (score > highScore)
        {
            highScore = score;

            PlayerPrefs.SetFloat("TOPSCORE", highScore);
        }

        PrintHighScore();
    }

    public void PrintHighScore()
    {
        highScore = PlayerPrefs.GetFloat("TOPSCORE");

        if (highScore < 10)
            TopscoreText.text = "HI 0000" + (int)highScore;
        else if (highScore < 100)
            TopscoreText.text = "HI 000" + (int)highScore;
        else if (highScore < 1000)
            TopscoreText.text = "HI 00" + (int)highScore;
        else if (highScore < 10000)
            TopscoreText.text = "HI 0" + (int)highScore;
        else
            TopscoreText.text = "HI " + (int)highScore;
    }

    public float getScore() { return this.score; }
}
