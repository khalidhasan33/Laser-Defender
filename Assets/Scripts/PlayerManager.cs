using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    float paddingLeft = 0.5f;
    float paddingRight = 0.5f;
    float paddingTop = 5f;
    float paddingBottom = 1f;

    Vector2 moveInput;

    Vector2 minBounds;
    Vector3 maxBounds;

    Shooter shooter;

    PlayerInput playerInput;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        InitBounds();
        playerInput = GetComponent<PlayerInput>();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0f, 0f));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1f, 1f));
    }

    void Update()
    {
        Fire();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 delta = moveInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Fire()
    {
        if(playerInput.actions["fire"].IsPressed())
        {
            shooter.StartFiring();
        }
        else
        {
            shooter.StopFiring();
        }
    }

}
