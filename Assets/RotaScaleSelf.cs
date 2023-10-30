
using UnityEngine;
using UnityEngine.EventSystems;

public class RotaScaleSelf : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IScrollHandler
{

    public Transform target; //目标模型

    private float scale = 1;//一般为模型初始缩放数值


    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0) //滚轮缩放
        {
            //改变物体大小 
            if (scale <= 0.5f )
            {
                scale = 0.51f;
            }
            if (scale >= 2f)
            {
                scale = 1.99f;
            }
            scale += Input.GetAxis("Mouse ScrollWheel") * 0.1f; //滚轮滑动数值返回0.1
            target.transform.localScale = new Vector3(1 * scale, 1 * scale, 1 * scale);


        }
    }


    private bool isMouseOnObject;//鼠标是否在滑动区

    public void OnDrag(PointerEventData eventData)//鼠标拖动
    {
        if (!isMouseOnObject) return;
        //得到和拖动平面相切的一个垂直向量，再标准化得到对应平面的法向量 
        Vector3 cross = Vector3.Cross(new Vector3(eventData.delta.x, eventData.delta.y), Vector3.forward).normalized;
        //以和鼠标拖动平面垂直的法向量，作为自转的轴
        //拖动距离的长度作为自转的角度
        transform.Rotate(cross, eventData.delta.magnitude * 0.3f, Space.World);
    }

    public void OnPointerEnter(PointerEventData eventData)//鼠标进入
    {
        isMouseOnObject = true;
        print("11");
    }

    public void OnPointerExit(PointerEventData eventData)//鼠标离开
    {
        isMouseOnObject = false;
        print("22");
    }

    public void OnScroll(PointerEventData eventData)//滚轮
    {
        print("33");
        if (!isMouseOnObject) return;
        transform.localScale += eventData.scrollDelta.y * Vector3.one * 0.05f;
        if (transform.localScale.x <= 0.3f)
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        if (transform.localScale.x >= 1.8f)
            transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
    }

    private void OnEnable()//切换时恢复旋转和缩放
    {
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

}
