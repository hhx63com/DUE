using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    [Header("Resolution Settings")]
    public bool useFixedResolution = false;
    public int fixedWidth = 1920;
    public int fixedHeight = 1080;
    public bool fullScreen = false;
    
    [Header("Responsive Settings")]
    public bool useAspectRatio = true;
    public float targetAspectRatio = 16f / 9f;
    
    [Header("UI Settings")]
    public CanvasScaler canvasScaler;
    public bool autoAdjustCanvas = true;
    
    void Start()
    {
        if (useFixedResolution)
        {
            // 使用固定分辨率
            Screen.SetResolution(fixedWidth, fixedHeight, fullScreen);
        }
        else if (useAspectRatio)
        {
            // 保持目标宽高比
            AdjustToTargetAspectRatio();
        }
        
        // 自动调整Canvas
        if (autoAdjustCanvas && canvasScaler != null)
        {
            SetupCanvasScaler();
        }
    }
    
    void AdjustToTargetAspectRatio()
    {
        float currentAspectRatio = (float)Screen.width / Screen.height;
        
        if (Mathf.Abs(currentAspectRatio - targetAspectRatio) > 0.01f)
        {
            // 计算合适的分辨率
            if (currentAspectRatio > targetAspectRatio)
            {
                // 屏幕太宽，保持高度不变
                int newWidth = Mathf.RoundToInt(Screen.height * targetAspectRatio);
                Screen.SetResolution(newWidth, Screen.height, fullScreen);
            }
            else
            {
                // 屏幕太高，保持宽度不变
                int newHeight = Mathf.RoundToInt(Screen.width / targetAspectRatio);
                Screen.SetResolution(Screen.width, newHeight, fullScreen);
            }
        }
    }
    
    void SetupCanvasScaler()
    {
        if (canvasScaler != null)
        {
            // 设置CanvasScaler为按屏幕尺寸缩放
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            
            // 设置参考分辨率
            canvasScaler.referenceResolution = new Vector2(fixedWidth, fixedHeight);
            
            // 设置屏幕匹配模式
            canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            
            // 设置匹配比例（0 = 宽度优先，1 = 高度优先）
            canvasScaler.matchWidthOrHeight = 0.5f; // 平均匹配
        }
    }
    
    // 手动调整分辨率的方法
    public void SetResolution(int width, int height, bool isFullScreen)
    {
        Screen.SetResolution(width, height, isFullScreen);
    }
    
    // 切换全屏模式
    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    
    // 适应当前屏幕
    public void AdaptToCurrentScreen()
    {
        if (useAspectRatio)
        {
            AdjustToTargetAspectRatio();
        }
    }
}
