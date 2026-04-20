using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseOnClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject pauseUI;
    private bool isPaused = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        TogglePause();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            if (pauseUI != null)
            {
                pauseUI.SetActive(true);
            }
        }
        else
        {
            Time.timeScale = 1f;
            if (pauseUI != null)
            {
                pauseUI.SetActive(false);
            }
        }
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            if (pauseUI != null)
            {
                pauseUI.SetActive(false);
            }
        }
    }
}
