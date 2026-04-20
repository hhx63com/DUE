using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextOnClick : MonoBehaviour
{
    public GameObject textPanel;
    public Text displayText;
    public string message = "Hello, World!";

    public void ShowText()
    {
        if (textPanel != null)
        {
            textPanel.SetActive(true);
        }

        if (displayText != null)
        {
            displayText.text = message;
        }
    }

    public void HideText()
    {
        if (textPanel != null)
        {
            textPanel.SetActive(false);
        }
    }
}
