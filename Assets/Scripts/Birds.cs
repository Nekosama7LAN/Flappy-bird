using System;
using System.Collections;
using UnityEngine;

public class Birds : MonoBehaviour
{

    public event Action OnDeath;
    public event Action ScoreCount;

    private float initialGravityScale;

    private bool isPlaying = false;

    private Rigidbody2D rigidB;

    [SerializeField] private Vector2 jump;

    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
        isPlaying = false;
        initialGravityScale = rigidB.gravityScale;
        rigidB.gravityScale = 0;
    }
    public void ActiveBird()
    {
        Jump();
        isPlaying = true;
        rigidB.gravityScale = initialGravityScale;
    }
    void Control()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) )
             Jump();
        
        
    }
    void Jump()
    {
        rigidB.velocity = jump;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPlaying && collision.collider.CompareTag("Obstacle"))
        {
            Lose();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlaying && collision.CompareTag("Hitbox score"))
        {
            ScoreBoost();
        }
    }
    void Lose()
    {
        isPlaying = false;
        OnDeath?.Invoke();
    }
    void ScoreBoost()
    {
        ScoreCount?.Invoke();
    }
    void Update()
    {
        if (isPlaying == false)
        {
            return;
        }
        Control();

    }
}
