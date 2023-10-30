using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    //[SerializeField]
    //private Text pageNumber;
    //[SerializeField]
    //private InputField inputField;
    //[SerializeField]
    private PageView pageView;

    private int curPage = -1;


    void Start()
    {
        //pageNumber.text = string.Format("��ǰҳ�룺0���ܹ�ҳ��: {0}", pageView.GetPageCount());
        //pageView.OnPageChanged = pageChanged;

        //pageView.ScrollToPage(0, true);
    }

    void pageChanged(int index)
    {
        //pageNumber.text = string.Format("��ǰҳ�룺{0}�� �ܹ�ҳ��: {1}", index.ToString(), pageView.GetPageCount());
        //curPage = index;
    }

    //����ĳҳ
    public void SetPageIndex(int index)
    {
        pageView.ScrollToPage(index);
    }
    public void onClick()
    {
        //try
        //{
        //    int idnex = int.Parse(inputField.text);
        //    pageView.ScrollToPage(idnex);
        //}
        //catch (Exception ex)
        //{
        //    Debug.LogWarning("����������" + ex.ToString());
        //}
    }

    void Destroy()
    {
        pageView.OnPageChanged = null;
    }

    public void onLeftClick()
    {
        curPage--;
        if (curPage < 0) curPage = 0;
        pageView.ScrollToPage(curPage);
    }

    public void onRightClick()
    {
        curPage++;
        if (curPage >= pageView.GetPageCount()) curPage = pageView.GetPageCount() - 1;
        pageView.ScrollToPage(curPage);
    }
}