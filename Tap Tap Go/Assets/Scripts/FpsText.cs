using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class FpsText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI FPS;


    private float poolingTime = 0.5f;
    private float time;
    private int frames;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        if (Application.isMobilePlatform)
            QualitySettings.vSyncCount = 0;
    }
    void Update()
    {
        time += Time.deltaTime;

        frames++;

        if (time > poolingTime)
        {
            int Frames = Mathf.RoundToInt(frames / time);

            FPS.text = Frames.ToString() + "FPS";
            time -= poolingTime;
            frames = 0;
        }

    }
}
