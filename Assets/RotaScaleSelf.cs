
using UnityEngine;
using UnityEngine.EventSystems;

public class RotaScaleSelf : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IScrollHandler
{

    public Transform target; //Ŀ��ģ��

    private float scale = 1;//һ��Ϊģ�ͳ�ʼ������ֵ


    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0) //��������
        {
            //�ı������С 
            if (scale <= 0.5f )
            {
                scale = 0.51f;
            }
            if (scale >= 2f)
            {
                scale = 1.99f;
            }
            scale += Input.GetAxis("Mouse ScrollWheel") * 0.1f; //���ֻ�����ֵ����0.1
            target.transform.localScale = new Vector3(1 * scale, 1 * scale, 1 * scale);


        }
    }


    private bool isMouseOnObject;//����Ƿ��ڻ�����

    public void OnDrag(PointerEventData eventData)//����϶�
    {
        if (!isMouseOnObject) return;
        //�õ����϶�ƽ�����е�һ����ֱ�������ٱ�׼���õ���Ӧƽ��ķ����� 
        Vector3 cross = Vector3.Cross(new Vector3(eventData.delta.x, eventData.delta.y), Vector3.forward).normalized;
        //�Ժ�����϶�ƽ�洹ֱ�ķ���������Ϊ��ת����
        //�϶�����ĳ�����Ϊ��ת�ĽǶ�
        transform.Rotate(cross, eventData.delta.magnitude * 0.3f, Space.World);
    }

    public void OnPointerEnter(PointerEventData eventData)//������
    {
        isMouseOnObject = true;
        print("11");
    }

    public void OnPointerExit(PointerEventData eventData)//����뿪
    {
        isMouseOnObject = false;
        print("22");
    }

    public void OnScroll(PointerEventData eventData)//����
    {
        print("33");
        if (!isMouseOnObject) return;
        transform.localScale += eventData.scrollDelta.y * Vector3.one * 0.05f;
        if (transform.localScale.x <= 0.3f)
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        if (transform.localScale.x >= 1.8f)
            transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
    }

    private void OnEnable()//�л�ʱ�ָ���ת������
    {
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

}
