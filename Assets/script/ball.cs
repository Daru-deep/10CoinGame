using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TMPro;

public class ball : MonoBehaviour
{
    public GameObject WallcolidersLeft;
    public GameObject WallcolidersRight;
    
    private Rigidbody2D rb;
    [System.NonSerialized]
    public float power = 0f;
    public bool left = false;
    public bool right = false;
    private Vector2 startPoint = new Vector2(-3.7f, 3.7f);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetKey(KeyCode.Space)&&power<3000f&&left==true)
        {
            power = power + 10f;
            Debug.Log("InputSpace");

            
        } else if (Input.GetKeyUp(KeyCode.Space) && left == true)
        {   
            Vector2 forth = new Vector2(power,power/100);
            rb.AddForce(forth);
            power = 0f;
            left = false;
        }

        if (Input.GetKey(KeyCode.Space) && power > -3000f && right == true)
        {
            power = power - 10f;
            Debug.Log("InputSpace");


        }
        else if (Input.GetKeyUp(KeyCode.Space) && right == true)
        {
            Vector2 forth = new Vector2(power, power / -100);
            rb.AddForce(forth);
            power = 0f;
            left = false;
        }

    }
    void OnTriggerEnter2D(Collider2D col)//���ɗ������珉���ʒu��
    {
        if (col.gameObject.name == "out-hole")
        {
            this.transform.position = startPoint;
            this.power = 0;
        }else if(col.gameObject.name == "goal-hole")
        {
            this.transform.position = startPoint;
            this.power = 0;
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            //ゲームポイント加算
            gm.SetPoint(gm.GetPoint() + 10);
        }
    }

    void OnCollisionEnter2D(Collision2D col)//�ǂɓ������Ă��鎞�ɕϐ���true��
    {
        if (col.gameObject.name == "Wall-Left")
        {
            left = true;
            Debug.Log("Go is true");
        }else if (col.gameObject.name == "Wall-Right")
        {
            right =true;
        }

    }

    private void OnCollisionExit2D(Collision2D col)//���ꂽ����false��
    {
        if (col.gameObject.name == "Wall-Left")
        {
            left = false;
        }else if(col.gameObject.name == "Wall-Right")
        {
            right = false;
        }
    }
}
