using UnityEngine;
using System.Collections;

public class DragRound : MonoBehaviour
{
    public Transform rotTarget;

    public float speed = 2f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float OffsetX = Input.GetAxis("Mouse X");
            float OffsetY = Input.GetAxis("Mouse Y");
            if (Mathf.Abs(OffsetY) > Mathf.Abs(OffsetX))//�Ա�ˮƽ����ֱ����˭��λ����������������ת�ĸ����򣬱���������λ�ơ�
                transform.Rotate(new Vector3(OffsetY, 0, 0) * speed, Space.World);
            else
                transform.Rotate(new Vector3(0, 0, 0) * speed, Space.World);


        }
    }

}