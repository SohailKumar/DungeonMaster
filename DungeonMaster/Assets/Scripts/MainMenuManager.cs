using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject creditsPanel;
    public void StartGame()
    {
        SceneManager.LoadScene("GridDemo");
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void HideCredits()
    {
        creditsPanel.SetActive(false);
    }
}
