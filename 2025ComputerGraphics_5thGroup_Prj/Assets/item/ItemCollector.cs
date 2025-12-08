// 탈출 조건 + 아이템 UI 설정 2025.11.30
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public int collected = 0;
    public int requiredCount = 6;
    void Start()
    {
        ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            collected++;

            Destroy(other.gameObject);
        }
    }

    public bool HasEnoughItems()
    {
        return collected >= requiredCount;
    }
}
