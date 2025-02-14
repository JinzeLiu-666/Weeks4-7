using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class IngredientDropdownManager : MonoBehaviour
{
    public TMP_Dropdown ingredientDropdown; // �����˵�
    public List<Image> ingredientImages; // �洢����ѡ���ͼ��

    void Start()
    {
        ingredientDropdown.onValueChanged.AddListener(UpdateSelectedImage);
        HideAllImages(); // ����ʱ��������ͼƬ
    }

    void UpdateSelectedImage(int selectedIndex)
    {
        HideAllImages(); // ����������ͼƬ

        // ֻ��ʾ��ǰѡ�е�ͼƬ
        if (selectedIndex > 0 && selectedIndex < ingredientImages.Count)
        {
            ingredientImages[selectedIndex].gameObject.SetActive(true);
        }
    }

    void HideAllImages()
    {
        foreach (Image img in ingredientImages)
        {
            img.gameObject.SetActive(false);
        }
    }
}
