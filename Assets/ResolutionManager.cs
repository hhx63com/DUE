using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    [Header("分辨率设置")]
    public int targetWidth = 1920;        // 目标宽度
    public int targetHeight = 1080;       // 目标高度
    public bool fullScreen = true;        // 是否全屏

    [Header("Canvas 设置")]
    public Canvas targetCanvas;            // 指定要设置的 Canvas（如果不指定，会尝试找场景中的第一个 Canvas）
    public CanvasScaler.ScaleMode scaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

    void Awake()
    {
        // 1. 设置游戏窗口分辨率
        Screen.SetResolution(targetWidth, targetHeight, fullScreen);
        Debug.Log($"[ResolutionManager] 分辨率设置为 {targetWidth}x{targetHeight}, 全屏: {fullScreen}");

        // 2. 自动配置 CanvasScaler（如果存在 Canvas）
        ConfigureCanvasScaler();
    }

    void ConfigureCanvasScaler()
    {
        // 如果没有手动指定 Canvas，则尝试查找场景中第一个激活的 Canvas
        if (targetCanvas == null)
            targetCanvas = FindObjectOfType<Canvas>();

        if (targetCanvas == null)
        {
            Debug.LogWarning("[ResolutionManager] 场景中没有找到 Canvas 组件，请手动添加 CanvasScaler。");
            return;
        }

        // 获取或添加 CanvasScaler 组件
        CanvasScaler scaler = targetCanvas.GetComponent<CanvasScaler>();
        if (scaler == null)
            scaler = targetCanvas.gameObject.AddComponent<CanvasScaler>();

        // 设置缩放模式
        scaler.uiScaleMode = scaleMode;

        // 如果是 ScaleWithScreenSize 模式，设置参考分辨率（与目标分辨率一致）
        if (scaleMode == CanvasScaler.ScaleMode.ScaleWithScreenSize)
        {
            scaler.referenceResolution = new Vector2(targetWidth, targetHeight);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            scaler.matchWidthOrHeight = 0.5f; // 平衡宽高影响
        }

        Debug.Log($"[ResolutionManager] CanvasScaler 已配置: 模式={scaleMode}, 参考分辨率={scaler.referenceResolution}");
    }
}