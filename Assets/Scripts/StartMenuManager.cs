using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public Text playerNameText;
    public Text bestPlayerScoreText;

    private void Update()
    {
        if (StateManager.Instance.BestPlayerScore > 0)
        {
            bestPlayerScoreText.gameObject.SetActive(true);
            bestPlayerScoreText.text = $"Best Score: {StateManager.Instance.BestPlayerName}: {StateManager.Instance.BestPlayerScore}";
        }
    }

    public void StartGame()
    {
        StateManager.Instance.CurrentPlayerName = playerNameText.text;
        SceneManager.LoadScene("main");
    }
}
