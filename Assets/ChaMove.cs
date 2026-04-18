using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChaMove : MonoBehaviour
{
    public float speed = 3;
    private int count;

    public AudioManager audioManager;
    public TextMeshProUGUI countText;

    // --- 新增：声明 WinPanel 变量 ---
    public GameObject winPanel;
    // --- 结束新增 ---


    Animator anim;
    Vector3 move;

    void Start()
    {
        anim = GetComponent<Animator>();
        count = 0;
        //countText.text = "Count: " + count.ToString();

    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        move = new Vector3(x, 0, z);
        transform.LookAt(transform.position + new Vector3(x, 0, z));
        transform.position += new Vector3(x, 0, z) * speed * Time.deltaTime;


        UpdateAnim();
    }


    void UpdateAnim()
    {
        anim.SetFloat("Speed", move.magnitude);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (audioManager != null)
            {
                audioManager.PlayHitSound();
            }

            other.gameObject.SetActive(false);
            count ++;
            //countText.text = "Count: " + count.ToString();

            // --- 新增：检查胜利条件 ---
            CheckWinCondition();
            // --- 结束新增 ---
        }
        else if (other.gameObject.CompareTag("Bonus"))
        {
            other.gameObject.SetActive(false);
            count += 10;
            //countText.text = "Count: " + count.ToString();

            // 加分后也要检查胜利条件
            CheckWinCondition();
        }
    }

    // --- 新增：胜利判断函数 ---
    void CheckWinCondition()
    {
        // 当分数达到或超过11分时
        if (count >= 10)
        {
            // 激活 WinPanel，显示胜利界面
            winPanel.SetActive(true);

            // 可选：如果你想让游戏停止，可以取消下面这行的注释
            // Time.timeScale = 0;
        }
    }
    // --- 结束新增 ---
}