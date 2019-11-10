using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuChange : MonoBehaviour
{
    public GameObject from;
    public GameObject to;

    public void OnClick()
    {
        from.SetActive(false);
        to.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }

}


