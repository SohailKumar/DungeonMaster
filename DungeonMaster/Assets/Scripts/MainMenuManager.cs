using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public GameObject creditsPanel;

    public void StartGame()
    {
        Progression.roundNumber = 0;
        CurrencySystem.Instance.addMoney(20);
        source.PlayOneShot(clip);
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
