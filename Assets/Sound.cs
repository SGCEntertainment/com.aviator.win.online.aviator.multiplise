using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour
{
    private bool isMuteSound;

    private void Start()
    {
        isMuteSound = PlayerPrefs.GetInt("MuteSound") == 1;
        AudioListener.pause = isMuteSound;
    }

    public void MuteSound()
    {
        isMuteSound = !isMuteSound;
        AudioListener.pause = isMuteSound;
        PlayerPrefs.SetInt("MuteSound", isMuteSound ? 1 : 0);
        Debug.Log(isMuteSound);
    }

    public void Game()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
