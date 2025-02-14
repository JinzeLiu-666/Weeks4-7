using UnityEngine;
using UnityEngine.UI;

public class FireControl : MonoBehaviour
{
    public Slider fireSlider; // 滑块
    public GameObject fireObject; // 火焰对象

    void Start()
    {
        // 监听滑动条数值变化
        fireSlider.onValueChanged.AddListener(UpdateFireLevel);
        UpdateFireLevel(fireSlider.value); // 初始化火焰状态
    }

    void UpdateFireLevel(float value)
    {
        int fireLevel = (int)value; // 转换为整数

        // 根据火力大小调整火焰显示
        if (fireLevel == 0)
        {
            fireObject.SetActive(false); // 关闭火焰
        }
        else
        {
            fireObject.SetActive(true); // 开启火焰
            fireObject.transform.localScale = new Vector3(0f + fireLevel * 0.4f, 0f + fireLevel * 0.4f, 1f);
        }
    }
}
