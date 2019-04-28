using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    public static int sceneIndex = 1;
    public Image progress;

	// Use this for initialization
	void Start () {
        LoadScene();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene()
    {
        StartCoroutine(LoadNewScene(sceneIndex));
    }

    IEnumerator LoadNewScene(int scene)
    {

        yield return new WaitForSeconds(1);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            float progressLoading = Mathf.Clamp01(async.progress / .9f);
            progress.fillAmount = progressLoading;
            yield return null;
        }

    }
}
