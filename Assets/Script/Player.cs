using System.Collections;
using System.Collections.Generic;
using UnityEditor.VisionOS;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField]
    private float _moveSpeed = 7.5f;

    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;
	private void Awake()
	{
		shooter = GetComponent<Shooter>();
	}

	[SerializeField] private float _paddingLeft = 0.5f;
    [SerializeField] private float _paddingRight = 0.5f;
    [SerializeField] private float _paddingTop = 5f;
    [SerializeField] private float _paddingBottom = 2f;

	private void Start()
	{
		InitBounds();
	}
	// Update is called once per frame
	void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
	}

	void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

	private void Move()
    {
		Vector2 delta = rawInput * Time.deltaTime * _moveSpeed;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + _paddingLeft, maxBounds.x - _paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + _paddingBottom, maxBounds.y - _paddingTop);
		transform.position = newPos;
	}

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
