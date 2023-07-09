using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public GameObject creditsPanel;

    private void Start()
    {

        
    }
    public void StartGame()
    {
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
