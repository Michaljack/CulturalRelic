using UnityEngine;
using System.Collections;

//操作方式
public enum ControlType
{
	mouseControl,
	touchControl,
}

public class RotateObject1 : MonoBehaviour
{
	public ControlType controlType;
    public Transform rotTarget;

	//旋转速度加成系数
    public float rotSpeedScalar;
    private float currentSpeed = 0;

    void Start()
    {
        currentSpeed = Mathf.Lerp(-10, 0, 0.5f * Time.deltaTime);

    }

    void Update()
    {
        if (controlType==ControlType.mouseControl)
        {
            //鼠标操作
            if (Input.GetMouseButton(0))
            {
                    //拖动时速度
					//鼠标或手指在该帧移动的距离*deltaTime为手指移动的速度,此处为Input.GetAxis("Mouse X") / Time.deltaTime
					//不同帧率下lerp的第三个参数(即混合比例)也应根据帧率而不同--
					//考虑每秒2帧和每秒100帧的情况，如果此参数为固定值，那么在2帧的情况下，一秒后达到目标速度的0.75,而100帧的情况下，一秒后则基本约等于目标速度
                    currentSpeed = Mathf.Lerp(currentSpeed, Input.GetAxis("Mouse X") / Time.deltaTime,0.5f*Time.deltaTime);
                //currentSpeed = Mathf.Lerp(currentSpeed, Input.GetAxis("Mouse Y") / Time.deltaTime, 0.5f * Time.deltaTime);
            }
            else
            {
                //放开时速度
                currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.5f*Time.deltaTime);
            }
        }
		else if(controlType==ControlType.touchControl)
        {
            //触摸操作
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
				//在安卓设备上也可以用Mouse X,根据实验，touch[0].deltaPosition.x的值总是比Mouse X的值大很多，所以此处使用Mouse X
				currentSpeed = Mathf.Lerp(currentSpeed, Input.GetAxis("Mouse X")/Time.deltaTime,0.5f*Time.deltaTime);
            } 
			else
            {
                //放开时速度
                currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.5f*Time.deltaTime);
            }
        }
        rotTarget.Rotate(Vector3.down, Time.deltaTime * currentSpeed * rotSpeedScalar);
    }
}