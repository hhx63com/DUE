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

    public GameObject winPanel;


    Animator anim;
    Vector3 move;

    void Start()
    {
        anim = GetComponent<Animator>();
        count = 0;
        countText.text = "Count: " + count.ToString();

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

            audioManager.PlayHitSound();


            other.gameObject.SetActive(false);
            count ++;
            countText.text = "Count: " + count.ToString();


            CheckWinCondition();

        }
        else if (other.gameObject.CompareTag("Bonus"))
        {


            audioManager.PlayHitSound();

            other.gameObject.SetActive(false);
            count += 10;
            countText.text = "Count: " + count.ToString();


            CheckWinCondition();
        }
    }


    void CheckWinCondition()
    {

        if (count >= 10)
        {

            winPanel.SetActive(true);


            //Time.timeScale = 0;
        }
    }

}