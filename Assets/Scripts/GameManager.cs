using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI PointsText;
    public GameObject HealthContainer;
    public GameObject HealthUIItemPreFab;

    public GameObject GamerOverUI;
    public GameObject HighscoreUI;
    public TMP_InputField NameInputField;
    public HighscoreManager HighscoreManager;

    private int _points;

    private void Awake()
    {
        GamerOverUI.SetActive(false);
        HighscoreUI.SetActive(false);
    }

    public void GameOver()
    {
        GamerOverUI.SetActive(true);

        var IsNewHighscore = HighscoreManager.IsNewHighscore(_points);
        HighscoreUI.SetActive(IsNewHighscore);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddToHighscore()
    {
        var playerName = NameInputField.text;
        if (string.IsNullOrWhiteSpace(playerName))
        {
            return;
        }

        HighscoreManager.Add(playerName, _points);
        HighscoreUI.SetActive(false);
    }

    public void AddPoints(int points)
    {
        _points += points;
        PointsText.text = _points.ToString();
    }

    public void SetHealth(float health)
    {
        for (var i = HealthContainer.transform.childCount - 1; i >= 0; i--)
        {
            var child = HealthContainer.transform.GetChild(i);
            Destroy(child.gameObject);
        }

        for (var i = 0; i < health; i++)
        {
            Instantiate(HealthUIItemPreFab, HealthContainer.transform);
        }
    }
}
