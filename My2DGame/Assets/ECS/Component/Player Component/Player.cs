using UnityEngine;
public struct Player
{
    public GameObject playerPrefab;
    public Rigidbody2D rigidbody2D;
    public Vector2 velocity;
    public float speed;
    public float gravity;
    public Transform playerTransform;
    public Animator playerAnimator;
}