using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{
    public float destroyY = -3f; // 低于这个高度自动销毁

    void Update()
    {
        if (transform.position.y <= destroyY)
        {
            Destroy(gameObject); // 自动销毁药材
        }
    }
}
