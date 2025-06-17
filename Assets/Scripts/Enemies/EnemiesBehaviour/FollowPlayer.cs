using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private GameObject player;

    [Header("Movement")]
    [SerializeField] private float speed = 2f;
    private Rigidbody2D rb;
    private Vector2 direction;

    [Header("Chase Logic")]
    private Vector3 startingPosition;

    #region System
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    void FixedUpdate()
    {
        HandleChase();
    }
    #endregion

    #region Chase
    void HandleChase()
    {
        direction = (player.transform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    #endregion

    #region Utility
    float GetDistanceFromStart()
    {
        return Vector2.Distance(startingPosition, rb.position);
    }
    #endregion


    }
