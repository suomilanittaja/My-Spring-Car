﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterMovementController : MonoBehaviour
{
    public CharacterController characterController;

    public float moveSpeed;

    public float sprintSpeedMultiplier = 2f;

    public float jumpHeight = 3f;

    private float _gravity = -10f;

    private float _yAxisVelocity;
	
	public Slider stamina;
	
	public float value2;
	
	public bool canJump;
	
	
	public void Start()
	{
		canJump = true;
	}


    private void Update()
    {
		value2 = stamina.value;
		
		float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) && value2 >= 5f)
			vertical *= sprintSpeedMultiplier;
        
        Vector3 movement = horizontal * moveSpeed * Time.deltaTime * transform.right +
                           vertical * moveSpeed * Time.deltaTime * transform.forward;

        if (characterController.isGrounded)
            _yAxisVelocity = -0.5f;


        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
		{
            _yAxisVelocity = Mathf.Sqrt(jumpHeight * -2f * _gravity);
			canJump = false;
			StartCoroutine(Time2());
			
		}

        _yAxisVelocity += _gravity * Time.deltaTime;
        movement.y = _yAxisVelocity * Time.deltaTime;
        
        characterController.Move(movement);
    }
	
	IEnumerator Time2()
	{	
		yield return new WaitForSeconds(1);
		canJump = true;
	}
}