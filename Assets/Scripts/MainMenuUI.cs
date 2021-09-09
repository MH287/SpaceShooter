using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;


public class MainMenuUI : MonoBehaviour
{
    public HighscoreManager HighscoreManager;
    public GameObject HighscoreEntries;
    public GameObject HighscoreEntryUIPrefab;

    private void Start()
    {
        ShowHighscores();
    }

    private void ShowHighscores()
    {
        for (var i = HighscoreEntries.transform.childCount - 1; i >= 0; i--)
        {
            var child = HighscoreEntries.transform.GetChild(i);
            Destroy(child.gameObject);
        }

        var highscores = HighscoreManager.List();

        foreach (var highscore in highscores)
        {
            var highscoreEntry = Instantiate(HighscoreEntryUIPrefab, HighscoreEntries.transform);
            var textMeshPro = highscoreEntry.GetComponent<TextMeshProUGUI>();
            textMeshPro.text = $"{highscore.Score} - {highscore.Name}";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void CloseGame()
    {
        if (Application.isEditor)
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }
        else
        {
            Application.Quit();
        }
    }
}
