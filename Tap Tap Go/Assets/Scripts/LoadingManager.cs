using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [SerializeField]
    private Slider LoadingSlider;
    [SerializeField]
    private GameObject BetweenAnimation;
    private AsyncOperation operation;
    
    
    private void Update()
    {
        if (LoadingSlider.value == LoadingSlider.maxValue)
        {
            BetweenAnimation.SetActive(true);
            StartCoroutine(ActivateScene());
        }
    }
    public void Load(int BuildIndex)
    {
        StartCoroutine(LoadScene(BuildIndex));
    }
    IEnumerator LoadScene(int BuildIndex)
    {
        operation = SceneManager.LoadSceneAsync(BuildIndex);
        operation.allowSceneActivation = false;
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            LoadingSlider.value = Mathf.MoveTowards(LoadingSlider.value,progress, 1f);


            yield return null;
        }
    }
    IEnumerator ActivateScene()
    {
        yield return new WaitForSeconds(2f);
        operation.allowSceneActivation = true;
    }
}
