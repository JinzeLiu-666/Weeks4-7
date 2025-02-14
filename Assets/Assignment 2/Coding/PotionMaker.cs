using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotionMaker : MonoBehaviour
{
    public GameObject[] potionPrefabs; // 5 种药水的 Prefab
    public Transform spawnPoint; // 药水生成位置 (点A)
    public Transform targetPoint; // 药水移动目标 (点B)
    public Button startButton; // "开始" 按钮
    public Button putButton; // "Put" 按钮
    public float moveSpeed = 2f; // 药水移动速度

    private GameObject currentPotion; // 记录当前生成的药水
    private bool canStart = false; // 只有点击 Put 按钮后，才能点击开始按钮

    void Start()
    {
        startButton.onClick.AddListener(StartPotionProcess);
        putButton.onClick.AddListener(PutAction);

        startButton.interactable = false; // 游戏开始时禁用“开始”按钮
    }

    void PutAction()
    {
        if (currentPotion != null)
        {
            Destroy(currentPotion);
            currentPotion = null; // 清空引用
        }
        canStart = true;
        startButton.interactable = true;
    }

    void StartPotionProcess()
    {
        if (!canStart) return; // 只有点击了“Put”按钮后，才能点击“开始”

        canStart = false; // 立即禁用按钮防止重复点击
        startButton.interactable = false;

        int randomIndex = Random.Range(0, potionPrefabs.Length);
        currentPotion = Instantiate(potionPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);

        StartCoroutine(MovePotionToCauldron(currentPotion));
    }

    IEnumerator MovePotionToCauldron(GameObject potion)
    {
        while (Vector3.Distance(potion.transform.position, targetPoint.position) > 0.1f)
        {
            potion.transform.position = Vector3.MoveTowards(potion.transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
