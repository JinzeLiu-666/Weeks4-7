using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{
    public float destroyY = -3f; // ��������߶��Զ�����

    void Update()
    {
        if (transform.position.y <= destroyY)
        {
            Destroy(gameObject); // �Զ�����ҩ��
        }
    }
}
