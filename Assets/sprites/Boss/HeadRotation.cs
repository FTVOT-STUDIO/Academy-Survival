using UnityEngine;

public class HeadRotation : MonoBehaviour
{
    public float speed;

    void Update()
    {
        // �Ӹ��� �ð�������� ȸ��
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }
}
