using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientSpawner : MonoBehaviour
{
    public TMP_Dropdown ingredientDropdown; // 材料选择
    public GameObject[] ingredientPrefabs; // 材料数组
    public Transform spawnArea; // 生成位置

    // X/Y 生成范围
    [Range(-10f, 10f)] public float minX = -2f;
    [Range(-10f, 10f)] public float maxX = 2f;

    [Range(0f, 10f)] public float minY = 5f;
    [Range(0f, 10f)] public float maxY = 6f;

    public float destroyY = -3f; // 材料掉落到这个Y轴高度时销毁

    public void SpawnIngredient()
    {
        int selectedIndex = ingredientDropdown.value; // 获取当前选择的材料索引

        if (selectedIndex > 0 && selectedIndex < ingredientPrefabs.Length) // 确保选中的是材料
        {
            // 在锅上方的范围内随机生成
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

            // 随机Z轴旋转角度
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

            // 生成预制体
            GameObject ingredient = Instantiate(ingredientPrefabs[selectedIndex], spawnPosition, randomRotation);

            // 添加自动销毁脚本
            ingredient.AddComponent<DestroyOnFall>().destroyY = destroyY;
        }
    }
}
