using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public Image fadePlane;
    public GameObject gameOverUI;

    public RectTransform newWaveBanner;

    void Start()
    {
        FindObjectOfType<Player>().OnDeath += OnGameOver;
    }
    void OnGameOver()
    {
        StartCoroutine(Fade(Color.clear, Color.black, 1));
        gameOverUI.SetActive(true);
    }

    IEnumerator Fade(Color colorFrom, Color colorTo, float time)
    {
        float speed = 1 / time;
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime * speed;
            fadePlane.color = Color.Lerp(colorFrom, colorTo, percent);
            yield return null;
        }
    }

    //input UI
    public void StartNewGame()
    {
        SceneManager.LoadScene("Game");
    }
}
