using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStart : MonoBehaviour
{
    [SerializeField]
    private GameObject LoadingScreen;
    private bool pause;
    private void Awake()
    {
        pause = true;
    }
    private void Update()
    {
        if (pause)
        {
            Time.timeScale = 0f;
        }
    }
    public void Resume()
    {
        pause = false;
        Time.timeScale = 1f;
        LoadingScreen.SetActive(false);
    }
}
