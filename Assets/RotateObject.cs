using UnityEngine;

public class RoteSelf : MonoBehaviour
{
    private bool isPress;//是否按下

    private Vector3 startPos;//开始位置
    private Vector3 endPos;//结束位置

    public float dis;//距离

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