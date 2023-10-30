using UnityEngine;
using System.Collections;

//������ʽ
public enum ControlType
{
	mouseControl,
	touchControl,
}

public class RotateObject1 : MonoBehaviour
{
	public ControlType controlType;
    public Transform rotTarget;

	//��ת�ٶȼӳ�ϵ��
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
            //������
            if (Input.GetMouseButton(0))
            {
                    //�϶�ʱ�ٶ�
					//������ָ�ڸ�֡�ƶ��ľ���*deltaTimeΪ��ָ�ƶ����ٶ�,�˴�ΪInput.GetAxis("Mouse X") / Time.deltaTime
					//��ͬ֡����lerp�ĵ���������(����ϱ���)ҲӦ����֡�ʶ���ͬ--
					//����ÿ��2֡��ÿ��100֡�����������˲���Ϊ�̶�ֵ����ô��2֡������£�һ���ﵽĿ���ٶȵ�0.75,��100֡������£�һ��������Լ����Ŀ���ٶ�
                    currentSpeed = Mathf.Lerp(currentSpeed, Input.GetAxis("Mouse X") / Time.deltaTime,0.5f*Time.deltaTime);
                //currentSpeed = Mathf.Lerp(currentSpeed, Input.GetAxis("Mouse Y") / Time.deltaTime, 0.5f * Time.deltaTime);
            }
            else
            {
                //�ſ�ʱ�ٶ�
                currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.5f*Time.deltaTime);
            }
        }
		else if(controlType==ControlType.touchControl)
        {
            //��������
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
				//�ڰ�׿�豸��Ҳ������Mouse X,����ʵ�飬touch[0].deltaPosition.x��ֵ���Ǳ�Mouse X��ֵ��ܶ࣬���Դ˴�ʹ��Mouse X
				currentSpeed = Mathf.Lerp(currentSpeed, Input.GetAxis("Mouse X")/Time.deltaTime,0.5f*Time.deltaTime);
            } 
			else
            {
                //�ſ�ʱ�ٶ�
                currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.5f*Time.deltaTime);
            }
        }
        rotTarget.Rotate(Vector3.down, Time.deltaTime * currentSpeed * rotSpeedScalar);
    }
}