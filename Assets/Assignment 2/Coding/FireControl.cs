using UnityEngine;
using UnityEngine.UI;

public class FireControl : MonoBehaviour
{
    public Slider fireSlider; // ����
    public GameObject fireObject; // �������

    void Start()
    {
        // ������������ֵ�仯
        fireSlider.onValueChanged.AddListener(UpdateFireLevel);
        UpdateFireLevel(fireSlider.value); // ��ʼ������״̬
    }

    void UpdateFireLevel(float value)
    {
        int fireLevel = (int)value; // ת��Ϊ����

        // ���ݻ�����С����������ʾ
        if (fireLevel == 0)
        {
            fireObject.SetActive(false); // �رջ���
        }
        else
        {
            fireObject.SetActive(true); // ��������
            fireObject.transform.localScale = new Vector3(0f + fireLevel * 0.4f, 0f + fireLevel * 0.4f, 1f);
        }
    }
}
