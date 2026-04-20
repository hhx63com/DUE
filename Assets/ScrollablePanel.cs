using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollablePanel : MonoBehaviour
{
    public GameObject scrollablePanel;
    public ScrollRect scrollRect;
    public Button closeButton;
    public Button openButton;

    void Start()
    {
        if (scrollablePanel != null)
        {
            scrollablePanel.SetActive(false);
        }

        if (openButton != null)
        {
            openButton.onClick.AddListener(OpenPanel);
        }

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(ClosePanel);
        }
    }

    public void OpenPanel()
    {
        if (scrollablePanel != null)
        {
            scrollablePanel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        if (scrollablePanel != null)
        {
            scrollablePanel.SetActive(false);
        }
    }

    void Update()
    {
        if (scrollablePanel != null && scrollablePanel.activeSelf)
        {
            // 处理鼠标滚轮事件
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            if (scrollInput != 0 && scrollRect != null)
            {
                scrollRect.verticalNormalizedPosition += scrollInput * 0.1f;
                scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition);
            }
        }
    }
}
