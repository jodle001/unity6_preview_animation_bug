using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private InputAction moveAction;

    private void Awake() {
        moveAction = InputManager.Instance.InputActions.Player.Move;
        animator = GetComponent<Animator>();
    }

    private void OnEnable() {
        moveAction.Enable();
    }
    
    private void OnDisable() {
        moveAction.Disable();
    }

    private void Update()
    {
        // Read movement input from the Input System
        // moveInput = InputManager.PlayerControls.Move.ReadValue<Vector2>();

        // Determine movement direction and update animator parameters
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        // Calculate movement direction based on moveInput
        bool isMoving = moveInput.magnitude > 0;
        bool isIdle = !isMoving;

        Debug.Log("moveInput:" + moveInput);

        // Update animator parameters based on movement direction
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isIdle", isIdle);

        // Determine facing direction based on moveInput
        if (moveInput != Vector2.zero)
        {
            animator.SetBool("facingDown", moveInput.y < 0);
            animator.SetBool("facingUp", moveInput.y > 0);
            animator.SetBool("facingLeft", moveInput.x < 0);
            animator.SetBool("facingRight", moveInput.x > 0);
        }
    }
}
