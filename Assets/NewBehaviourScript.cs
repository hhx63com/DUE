using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public void LoadMyScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    public void LoadMyScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
