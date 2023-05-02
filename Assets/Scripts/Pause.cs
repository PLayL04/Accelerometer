using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject from;
    public GameObject to;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void OnClick()
    {
        from.SetActive(false);
        to.SetActive(true);
        Time.timeScale = 0;
    }

    public void Begin()
    {
        from.SetActive(false);
        to.SetActive(true);
        Time.timeScale = 1;
    }

    public void End()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void Ed2()
    {
        SceneManager.LoadScene("Main1", LoadSceneMode.Single);
    }
}