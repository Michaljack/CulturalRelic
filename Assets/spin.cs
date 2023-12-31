using UnityEngine;

//物体添加刚体，忽略重力

// 自动围绕 Y 轴旋转
public class Spin : MonoBehaviour
{
    public Vector3 rotationsPerSecond = new Vector3(0f, 0.1f, 0f);
    public bool ignoreTimeScale = false;

    Rigidbody mRb;
    Transform mTrans;

    void Start()
    {
        mTrans = transform;
        mRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (mRb == null)
        {
            ApplyDelta(ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
        }
    }
    void FixedUpdate()
    {
        if (mRb != null)
        {
            ApplyDelta(Time.deltaTime);
        }
    }

    public void ApplyDelta(float delta)
    {
        delta *= Mathf.Rad2Deg * Mathf.PI * 2f;
        Quaternion offset = Quaternion.Euler(rotationsPerSecond * delta);

        if (mRb == null)
        {
            mTrans.rotation = mTrans.rotation * offset;
        }
        else
        {
            mRb.MoveRotation(mRb.rotation * offset);
        }
    }
}
