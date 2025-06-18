using UnityEngine;

public class XPDropper : MonoBehaviour
{
    [SerializeField] private GameObject xpPrefab10;
    [SerializeField] private GameObject xpPrefab50;
    [SerializeField] private GameObject xpPrefab100;
    [SerializeField] private GameObject xpPrefab500;
    [SerializeField] private GameObject xpPrefab1000;

    public void DropXP(int amount)
    {
        GameObject prefab = GetPrefabForAmount(amount);
        if (prefab != null)
        {
            Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }

    private GameObject GetPrefabForAmount(int amount)
    {
        switch (amount)
        {
            case 10:
                return xpPrefab10;
            case 50:
                return xpPrefab50;
            case 100:
                return xpPrefab100;
            case 500:
                return xpPrefab500;
            case 1000:
                return xpPrefab10;
            default:
                return xpPrefab1000;
        }
    }
}