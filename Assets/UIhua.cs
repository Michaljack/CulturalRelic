using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIhua : MonoBehaviour
{
    public Animator an;
    public Animator an2;
    public int a1;
    public GameObject UIB;
    public GameObject UI;

    public List<GameObject> ui1;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if(i==a1)
            {
                ui1[i].SetActive(true);
            }
            else
            {
                ui1[i].SetActive(false);
            }
        }

        AnimatorStateInfo info = an.GetCurrentAnimatorStateInfo(0);
        // 判断动画是否播放完成
        time += Time.deltaTime;
        if (info.normalizedTime >= 1.0f&&time>=1)
        {
            UI.SetActive(true);
            print("1");
        }
        else
        {
            print("2");
        }
    }
    public void hu0()
    {
        an2.SetInteger("hu", 0);

    }
    public void hu1()
    {
        an2.SetInteger("hu", 1);

    }
    public void hu2()
    {
        an2.SetInteger("hu", 2);

    }
    public void hu3()
    {
        an2.SetInteger("hu", 3);

    }
    public void jiazai()
    {
        SceneManager.LoadScene("列表");  //读取关卡level1
    }
    public void zuo()
    {
        UIB.SetActive(false);
        time = 0;
        hu0();
        a1 -= 1;
        if (a1 == 0)
        {
            an.SetInteger("a1", 0);
        }
        if (a1 == 1)
        {
            an.SetInteger("a1", 1);
        }
        if (a1 == 2)
        {
            an.SetInteger("a1", 2);
        }
        if (a1 == 3)
        {
            an.SetInteger("a1", 3);
        }
    }
    public void you()
    {
        hu0();
        time = 0;
        UIB.SetActive(false);
        a1 += 1;
        if(a1==0)
        {
            an.SetInteger("a1", 0);
        }
        if (a1 == 1)
        {
            an.SetInteger("a1", 1);
        }
        if (a1 == 2)
        {
            an.SetInteger("a1", 2);
        }
        if (a1 == 3)
        {
            an.SetInteger("a1", 3);
        }
        if(a1>=4)
        {
            a1 = 3;
        }
    }
}
