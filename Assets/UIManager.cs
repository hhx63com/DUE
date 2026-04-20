using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas mainCanvas;
    public CanvasScaler canvasScaler;
    
    void Start()
    {
        if (mainCanvas == null)
        {
            mainCanvas = FindObjectOfType<Canvas>();
        }
        
        if (canvasScaler == null && mainCanvas != null)
        {
            canvasScaler = mainCanvas.GetComponent<CanvasScaler>();
            if (canvasScaler == null)
            {
                canvasScaler = mainCanvas.gameObject.AddComponent<CanvasScaler>();
            }
        }
        
        SetupCanvasScaler();
    }
    
    void SetupCanvasScaler()
    {
        if (canvasScaler != null)
        {
            // 基本设置
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1920, 1080);
            canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            canvasScaler.matchWidthOrHeight = 0.5f;
            canvasScaler.referencePixelsPerUnit = 100;
        }
    }
    
    // 调整UI元素的布局
    public void AdjustUIElements()
    {
        // 这里可以添加针对特定UI元素的调整逻辑
        // 例如：调整按钮位置、文本大小等
    }
}
