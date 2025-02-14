using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class IngredientDropdownManager : MonoBehaviour
{
    public TMP_Dropdown ingredientDropdown; // 下拉菜单
    public List<Image> ingredientImages; // 存储所有选项的图标

    void Start()
    {
        ingredientDropdown.onValueChanged.AddListener(UpdateSelectedImage);
        HideAllImages(); // 启动时隐藏所有图片
    }

    void UpdateSelectedImage(int selectedIndex)
    {
        HideAllImages(); // 先隐藏所有图片

        // 只显示当前选中的图片
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
