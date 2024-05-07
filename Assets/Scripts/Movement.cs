using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected GameObject movingButtons;
    [SerializeField] protected GameObject upButtons;
    protected bool isAlive = true;
    float moveDirection;
    AudioSource footsteps;
    protected Rigidbody2D playerRigidbody;
    protected EdgeCollider2D feetCollider;
    protected Animator playerAnimator;
    void OnMove(InputValue direction)
    {
        moveDirection = direction.Get<Vector2>().x;
        
    }
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        feetCollider = GetComponent<EdgeCollider2D>();
        footsteps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        if (isAlive)
        {
            PlayerMove();
            PlayerFlip();
        }
    }

    void PlayerMove()
    {
        if (Mathf.Abs(playerRigidbody.velocityX) >= moveSpeed) 
        { 
            playerRigidbody.velocityX = moveSpeed * moveDirection;
            movingButtons.SetActive(false);
        }
        else 
        { 
            playerRigidbody.velocityX = playerRigidbody.velocityX*Mathf.Abs(moveDirection) + moveSpeed/20*moveDirection;
            
        }
        playerAnimator.SetBool("isWalking", true);

        if (playerRigidbody.velocityX != 0 && feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (!footsteps.isPlaying)
                footsteps.Play();
                Debug.Log("moving");
        }
        else
        {
            footsteps.Stop();
        }
    }

    void PlayerFlip()
    {
        if (playerRigidbody.velocityX != 0)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidbody.velocityX), 1f);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }

    }

    public void Die()
    {
        isAlive = false;
        playerRigidbody.velocity = new Vector2(0f, 0f);
        playerAnimator.SetBool("isWalking", false);
    }

    public void UnDie()
    {
        isAlive = true;
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    public void ShowMovingControls()
    {
        movingButtons.SetActive(true);
    }

    public void ShowUpControls()
    {
        upButtons.SetActive(true);
    }

    public void HideUpControls()
    {
        upButtons.SetActive(false);
    }
}
