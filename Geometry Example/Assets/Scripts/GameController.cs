using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public int sceneOrder;

    public static bool isPLaying;

	// Use this for initialization
	void Start () {
        isPLaying = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLoadingScene(int sceneIndex)
    {
        Time.timeScale = 1;
        SceneLoader.sceneIndex = sceneIndex;
        SceneManager.LoadScene(0);
    }

    public void StartRepeatScene()
    {
        StartCoroutine(RepeatScene());
    }

    IEnumerator RepeatScene()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(sceneOrder);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GetComponent<SoundManager>().PauseMusic();
        isPLaying = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        GetComponent<SoundManager>().UnPauseMusic();
        isPLaying = true;
    }
}
