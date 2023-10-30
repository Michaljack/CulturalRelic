using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class PageView : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{

    private ScrollRect rect;                        //�������  
    private float targethorizontal = 0;             //��������ʼ����  
    private bool isDrag = false;                    //�Ƿ���ק����  
    private List<float> posList = new List<float>();//���ÿҳ���ٽ�ǣ�ҳ������0��ʼ  
    private int currentPageIndex = -1;
    public Action<int> OnPageChanged;
    public RectTransform content;
    private bool stopMove = true;
    public float smooting = 2;                      //�����ٶ�  
    public float sensitivity = 0.3f;
    private float startTime;

    private float startDragHorizontal;
    public Transform toggleList;

    void Start()
    {
        rect = transform.GetComponent<ScrollRect>();
        var _rectWidth = GetComponent<RectTransform>();
        var tempWidth = ((float)content.transform.childCount * _rectWidth.rect.width);
        content.sizeDelta = new Vector2(tempWidth, _rectWidth.rect.height);

        //δ��ʾ�ĳ���
        float horizontalLength = content.rect.width - _rectWidth.rect.width;
        for (int i = 0; i < rect.content.transform.childCount; i++)
        {
            posList.Add(_rectWidth.rect.width * i / horizontalLength);
        }
    }

    void Update()
    {
        if (!isDrag && !stopMove)
        {
            startTime += Time.deltaTime;
            float t = startTime * smooting;

            float temp = Mathf.SmoothStep(0, 1, t);
            rect.horizontalNormalizedPosition = Mathf.Lerp(rect.horizontalNormalizedPosition, targethorizontal, temp);
            if (t >= 1)
                stopMove = true;
        }
    }

    public void ScrollToPage(int index, bool immediately = false)
    {
        if (index >= 0 && index < posList.Count)
        {
            if (immediately)
            {
                rect.horizontalNormalizedPosition = posList[index];
            }
            else
            {
                targethorizontal = posList[index]; //���õ�ǰ���꣬���º������в�ֵ  
                isDrag = false;
                startTime = 0;
                stopMove = false;
            }

            SetPageIndex(index);
        }
    }

    public int GetPageCount()
    {
        return posList.Count;
    }

    private void SetPageIndex(int index)
    {
        if (currentPageIndex != index)
        {
            currentPageIndex = index;
            if (OnPageChanged != null)
                OnPageChanged(index);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
        //��ʼ�϶�
        startDragHorizontal = rect.horizontalNormalizedPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float posX = rect.horizontalNormalizedPosition;
        posX += ((posX - startDragHorizontal) * sensitivity);
        posX = posX < 1 ? posX : 1;
        posX = posX > 0 ? posX : 0;
        int index = 0;
        float offset = Mathf.Abs(posList[index] - posX);

        for (int i = 1; i < posList.Count; i++)
        {
            float temp = Mathf.Abs(posList[i] - posX);
            if (temp < offset)
            {
                index = i;
                offset = temp;
            }
        }
        SetPageIndex(index);
        targethorizontal = posList[index]; //���õ�ǰ���꣬���º������в�ֵ  
        isDrag = false;
        startTime = 0;
        stopMove = false;
    }

}