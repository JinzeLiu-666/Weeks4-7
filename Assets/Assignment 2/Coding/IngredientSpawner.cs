using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientSpawner : MonoBehaviour
{
    public TMP_Dropdown ingredientDropdown; // ����ѡ��
    public GameObject[] ingredientPrefabs; // ��������
    public Transform spawnArea; // ����λ��

    // X/Y ���ɷ�Χ
    [Range(-10f, 10f)] public float minX = -2f;
    [Range(-10f, 10f)] public float maxX = 2f;

    [Range(0f, 10f)] public float minY = 5f;
    [Range(0f, 10f)] public float maxY = 6f;

    public float destroyY = -3f; // ���ϵ��䵽���Y��߶�ʱ����

    public void SpawnIngredient()
    {
        int selectedIndex = ingredientDropdown.value; // ��ȡ��ǰѡ��Ĳ�������

        if (selectedIndex > 0 && selectedIndex < ingredientPrefabs.Length) // ȷ��ѡ�е��ǲ���
        {
            // �ڹ��Ϸ��ķ�Χ���������
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

            // ���Z����ת�Ƕ�
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

            // ����Ԥ����
            GameObject ingredient = Instantiate(ingredientPrefabs[selectedIndex], spawnPosition, randomRotation);

            // ����Զ����ٽű�
            ingredient.AddComponent<DestroyOnFall>().destroyY = destroyY;
        }
    }
}
