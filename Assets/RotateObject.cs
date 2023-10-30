using UnityEngine;

public class RoteSelf : MonoBehaviour
{
    private bool isPress;//�Ƿ���

    private Vector3 startPos;//��ʼλ��
    private Vector3 endPos;//����λ��

    public float dis;//����

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPress = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isPress = false;
        }

        startPos = Input.mousePosition;
        if (isPress)
        {
            Vector2 offset = endPos - startPos;
            if (Mathf.Abs(offset.y) < Mathf.Abs(offset.x) && Mathf.Abs(offset.x) > dis)
            {
                transform.Rotate(Vector2.up * Time.deltaTime * offset.x * 10);
            }
        }
        endPos = Input.mousePosition;
    }
}