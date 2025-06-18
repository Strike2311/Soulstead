using System.Numerics;
using UnityEngine;

public class ItemGathering : MonoBehaviour
{
    private float gatherRange = 5f;
    private float speed = 7f;
    public LayerMask detectionLayer;
    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, gatherRange, detectionLayer);

        foreach (Collider2D hit in hits)
        {
            UnityEngine.Vector2 direction = (transform.position - hit.transform.position).normalized;
            Rigidbody2D hitRb = hit.gameObject.GetComponent<Rigidbody2D>();
            hitRb.MovePosition(hitRb.position + direction * speed * Time.fixedDeltaTime);
        }
    }
}
