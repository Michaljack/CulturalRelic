using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class liebiao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      //  Application.runInBackground = true;
       // Screen.SetResolution(1080, 1920, false);


    }

    // Update is called once per frame
    void Update()
    {
    }
    public void jiazai()
    {
        SceneManager.LoadScene("�б�");  //��ȡ�ؿ�level1
    }
}
