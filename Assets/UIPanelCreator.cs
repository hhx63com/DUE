using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPanelCreator : MonoBehaviour
{
    public Canvas canvas;
    public ScrollablePanel scrollablePanelScript;

    void Start()
    {
        if (canvas == null)
        {
            canvas = FindObjectOfType<Canvas>();
            if (canvas == null)
            {
                GameObject canvasObj = new GameObject("Canvas");
                canvas = canvasObj.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvasObj.AddComponent<CanvasScaler>();
                canvasObj.AddComponent<GraphicRaycaster>();
            }
        }

        CreateScrollablePanel();
        CreateOpenButton();
    }

    void CreateScrollablePanel()
    {
        // 创建面板容器
        GameObject panelContainer = new GameObject("ScrollablePanelContainer");
        panelContainer.transform.SetParent(canvas.transform, false);
        
        // 设置面板大小和位置
        RectTransform panelRect = panelContainer.AddComponent<RectTransform>();
        panelRect.sizeDelta = new Vector2(600, 400);
        panelRect.anchoredPosition = Vector2.zero;
        
        // 添加背景
        Image panelImage = panelContainer.AddComponent<Image>();
        panelImage.color = new Color(0.1f, 0.1f, 0.1f, 0.9f);
        
        // 添加ScrollRect
        ScrollRect scrollRect = panelContainer.AddComponent<ScrollRect>();
        
        // 创建内容面板
        GameObject contentPanel = new GameObject("ContentPanel");
        contentPanel.transform.SetParent(panelContainer.transform, false);
        RectTransform contentRect = contentPanel.AddComponent<RectTransform>();
        contentRect.sizeDelta = new Vector2(580, 800); // 内容高度大于面板高度
        contentRect.anchoredPosition = Vector2.zero;
        
        // 设置ScrollRect的content
        scrollRect.content = contentRect;
        scrollRect.horizontal = false;
        scrollRect.vertical = true;
        
        // 添加内容文本
        CreateScrollContent(contentPanel);
        
        // 创建关闭按钮
        GameObject closeButtonObj = new GameObject("CloseButton");
        closeButtonObj.transform.SetParent(panelContainer.transform, false);
        RectTransform closeButtonRect = closeButtonObj.AddComponent<RectTransform>();
        closeButtonRect.sizeDelta = new Vector2(50, 50);
        closeButtonRect.anchoredPosition = new Vector2(275, 175);
        
        Button closeButton = closeButtonObj.AddComponent<Button>();
        Image closeButtonImage = closeButtonObj.AddComponent<Image>();
        closeButtonImage.color = new Color(0.8f, 0.2f, 0.2f, 1f);
        
        GameObject closeTextObj = new GameObject("CloseText");
        closeTextObj.transform.SetParent(closeButtonObj.transform, false);
        TextMeshProUGUI closeText = closeTextObj.AddComponent<TextMeshProUGUI>();
        closeText.text = "X";
        closeText.fontSize = 24;
        closeText.color = Color.white;
        closeText.alignment = TextAlignmentOptions.Center;
        
        // 初始隐藏面板
        panelContainer.SetActive(false);
        
        // 配置ScrollablePanel脚本
        if (scrollablePanelScript != null)
        {
            scrollablePanelScript.scrollablePanel = panelContainer;
            scrollablePanelScript.scrollRect = scrollRect;
            scrollablePanelScript.closeButton = closeButton;
        }
    }

    void CreateScrollContent(GameObject contentPanel)
    {
        // 创建多行文本
        for (int i = 1; i <= 20; i++)
        {
            GameObject textObj = new GameObject("Text" + i);
            textObj.transform.SetParent(contentPanel.transform, false);
            RectTransform textRect = textObj.AddComponent<RectTransform>();
            textRect.sizeDelta = new Vector2(560, 30);
            textRect.anchoredPosition = new Vector2(0, -30 * (i - 1) - 15);
            
            TextMeshProUGUI text = textObj.AddComponent<TextMeshProUGUI>();
            text.text = "这是滚动内容第 " + i + " 行 - 可以使用鼠标滚轮上下滚动查看更多内容。";
            text.fontSize = 16;
            text.color = Color.white;
        }
    }

    void CreateOpenButton()
    {
        // 创建打开按钮
        GameObject openButtonObj = new GameObject("OpenScrollablePanelButton");
        openButtonObj.transform.SetParent(canvas.transform, false);
        RectTransform openButtonRect = openButtonObj.AddComponent<RectTransform>();
        openButtonRect.sizeDelta = new Vector2(200, 50);
        openButtonRect.anchoredPosition = new Vector2(0, -200);
        
        Button openButton = openButtonObj.AddComponent<Button>();
        Image openButtonImage = openButtonObj.AddComponent<Image>();
        openButtonImage.color = new Color(0.2f, 0.6f, 0.8f, 1f);
        
        GameObject openTextObj = new GameObject("OpenText");
        openTextObj.transform.SetParent(openButtonObj.transform, false);
        TextMeshProUGUI openText = openTextObj.AddComponent<TextMeshProUGUI>();
        openText.text = "打开滚动面板";
        openText.fontSize = 16;
        openText.color = Color.white;
        openText.alignment = TextAlignmentOptions.Center;
        
        // 配置ScrollablePanel脚本
        if (scrollablePanelScript != null)
        {
            scrollablePanelScript.openButton = openButton;
        }
    }
}
