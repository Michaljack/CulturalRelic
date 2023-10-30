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
            if (Mathf.Abs(OffsetY) > Mathf.Abs(OffsetX))//对比水平和竖直方向谁的位移量更大，来决定旋转哪个方向，避免多个方向位移。
                transform.Rotate(new Vector3(OffsetY, 0, 0) * speed, Space.World);
            else
                transform.Rotate(new Vector3(0, 0, 0) * speed, Space.World);


        }
    }

}