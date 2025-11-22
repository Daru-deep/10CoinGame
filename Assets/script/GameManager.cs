using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] StatusManager sm ;
    private float time = 0f;
    private int point = 0;
    public GameObject ball;
    public GameObject powerText;
    float power;
    TextMeshProUGUI tmp;
    public GameObject lever;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        tmp = powerText.GetComponent<TextMeshProUGUI>();
    }

    public float GetTime()
    {
        return time;
    }

    public int GetPoint()
    {
        return point;
    }   
    public void SetPoint(int p)
    {
        point = p;
    }

    // Update is called once per frame
    void Update()
    {

        //時間切れ
        if(Time.time > 30)
        {
            sm.UpdateTextFile(point);
            SceneManager.LoadScene("StartScene");
        }

        power = ball.GetComponent<ball>().power;
        if (Input.GetKey(KeyCode.Space))
        {
            this.tmp.text = power.ToString()+"power";
           Transform pos = this.lever.transform;
            Vector3 worldAngle= pos.localEulerAngles;
            if (power < 0)
            {
                worldAngle.z = (power * -1) / 80f;
            }
            else
            {
                worldAngle.z = power / 80f;
            }
            pos.eulerAngles = worldAngle;
            
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            this.tmp.text = "smash";
            
            Transform pos = this.lever.transform;
            Vector3 worldAngle = pos.localEulerAngles;
            worldAngle.z = 0;
            pos.eulerAngles = worldAngle;

        }



    }

     
    
}
