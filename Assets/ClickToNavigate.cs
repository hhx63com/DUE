using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickToNavigate : MonoBehaviour
{
    // 目标场景名称
    public string targetSceneName;
    
    // 鼠标悬停时的提示文本
    public string hoverText = "点击进入";
    
    // 模型介绍文本
    public string modelDescription = "这是一个模型";
    
    // 材质相关
    private Material originalMaterial;
    public Material hoverMaterial;
    
    // UI相关
    public Canvas canvas;
    public GameObject infoPanel;
    public Text descriptionText;
    public Button okButton;
    
    private Renderer objectRenderer;
    private bool isHovering = false;
    
    void Start()
    {
        // 获取渲染器组件
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            // 保存原始材质
            originalMaterial = objectRenderer.material;
        }
        
        // 确保对象有碰撞器
        if (GetComponent<Collider>() == null)
        {
            Debug.LogWarning("对象 " + gameObject.name + " 没有碰撞器，点击检测可能不起作用");
        }
        
        // 初始化UI
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
        
        // 绑定OK按钮事件
        if (okButton != null)
        {
            okButton.onClick.AddListener(OnOKButtonClick);
        }
    }
    
    void Update()
    {
        // 检测鼠标悬停
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                // 鼠标悬停在物体上
                if (!isHovering)
                {
                    OnMouseHover();
                    isHovering = true;
                }
            }
            else
            {
                // 鼠标离开物体
                if (isHovering)
                {
                    OnMouseExit();
                    isHovering = false;
                }
            }
        }
        else
        {
            // 鼠标离开物体
            if (isHovering)
            {
                OnMouseExit();
                isHovering = false;
            }
        }
    }
    
    void OnMouseHover()
    {
        // 鼠标悬停效果
        if (objectRenderer != null && hoverMaterial != null)
        {
            objectRenderer.material = hoverMaterial;
        }
        
        // 显示信息面板
        if (infoPanel != null)
        {
            if (descriptionText != null)
            {
                descriptionText.text = modelDescription;
            }
            infoPanel.SetActive(true);
        }
    }
    
    void OnMouseExit()
    {
        // 恢复原始材质
        if (objectRenderer != null && originalMaterial != null)
        {
            objectRenderer.material = originalMaterial;
        }
        
        // 隐藏信息面板
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }
    
    void OnOKButtonClick()
    {
        // 跳转到目标场景
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            try
            {
                SceneManager.LoadScene(targetSceneName);
                Debug.Log("跳转到场景: " + targetSceneName);
            }
            catch (System.Exception e)
            {
                Debug.LogError("场景跳转失败: " + e.Message);
            }
        }
        else
        {
            Debug.LogWarning("目标场景名称未设置");
        }
    }
}
