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
    public Text newWaveTitle;
    public Text newWaveEnemyCount;
    public Text scoreUI;
    public Text gameOverScoreUI;
    public RectTransform heathBar;
    Color semiBlack = new Color(0f, 0f, 0f, 0.9f);

    Spawner Spawner;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnDeath += OnGameOver;

    }

    private void Awake()
    {
        Spawner = FindObjectOfType<Spawner>();
        Spawner.OnNewWave += OnNewave;
    }

    private void Update()
    {
        scoreUI.text = ScoreKeeper.score.ToString("D6");
        float healthPercent = 0;
        if (player != null)
            healthPercent = player.health / player.startingHealth;

        heathBar.localScale = new Vector3(healthPercent, 1, 1);
    }

    void OnNewave(int waveNumber)
    {
        newWaveTitle.text = "- Wave " + waveNumber + " -";
        newWaveEnemyCount.text = "Enemies: " + Spawner.waves[waveNumber - 1].enemyCount;

        StartCoroutine(AnimateNewWave());
    }

    void OnGameOver()
    {
        Cursor.visible = true;
        StartCoroutine(Fade(Color.clear, semiBlack, 1));
        gameOverScoreUI.text = scoreUI.text;
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

    IEnumerator AnimateNewWave()
    {
        float delayTime = 1.5f;
        float speed = 1f;
        float animatePercent = 0;
        float dir = 1;
        float endDelayTime = Time.time + 1 / speed + delayTime;

        while (animatePercent >= 0)
        {
            animatePercent += Time.deltaTime * speed * dir;

            if (animatePercent >= 1)
            {
                animatePercent = 1;
                if (Time.time > endDelayTime)
                {
                    dir = -1;
                }
            }
            newWaveBanner.anchoredPosition = Vector2.up * Mathf.Lerp(-280, 45, animatePercent);
            yield return null;
        }
    }

    //input UI
    public void StartNewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
