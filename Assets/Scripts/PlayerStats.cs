using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	public float Health;
	public float healthOverTimer;
	
	public float Stamina;
	public float staminaOverTime;
	public float staminaOverTime2;
	
	public float Hunger;
	public float hungerOverTime;
	
	public float Thirst;
	public float thirstOverTime;
	
	
	public Slider HealthBar;
	public Slider StaminaBar;
	public Slider HungerBar;
	public Slider ThirstBar;
	
	public float minAmount = 0.1f;
	public float sprintSpeed = 5f;
	
	public GameObject Die;
	public GameObject Player;
	public GameObject Camera;
	
	private void Start()
	{
		HealthBar.maxValue = Health;
		StaminaBar.maxValue = Stamina;
		HungerBar.maxValue = Hunger;
		ThirstBar.maxValue = Thirst;
		
		updateUI();
	}	

	private void Update()
	{
		CalculateValues();
		if (Health <= 0.1f)
		{
			Camera.gameObject.SetActive(true);
			Die.gameObject.SetActive(true);
			Player.gameObject.SetActive(false);
			Cursor.lockState = CursorLockMode.Confined;
		}
	}
		
	private void CalculateValues()
	{
		Hunger -= hungerOverTime * Time.deltaTime;
		Thirst -= thirstOverTime * Time.deltaTime;
		
		if(Hunger <= minAmount || Thirst <= minAmount)
		{
			Health -= healthOverTimer * Time.deltaTime;
			Stamina -= staminaOverTime * Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.LeftShift))
		{
			Stamina -= staminaOverTime * Time.deltaTime;
			Hunger -= hungerOverTime * Time.deltaTime;
			Thirst -= thirstOverTime * Time.deltaTime;
		}
		else
		{
			Stamina += staminaOverTime2 * Time.deltaTime;
		}
		
		if(Health <= 0)
		{
			print ("player has died");
		}
		
		
		updateUI();
	}
	
	private void updateUI()
	{
		Health = Mathf.Clamp(Health, 0, 100f);
		Stamina = Mathf.Clamp(Stamina, 0, 100f);
		Hunger = Mathf.Clamp(Hunger, 0, 100f);
		Thirst = Mathf.Clamp(Thirst, 0, 100f);
		
		HealthBar.value = Health;
		StaminaBar.value = Stamina;
		HungerBar.value = Hunger;
		ThirstBar.value = Thirst;
	}
	
	public void TakeDamage(float amnt)
	{
		Health -= amnt;
		updateUI();
	}
	
	public void Drink()
	{
		Thirst += 20;
	}
	
	public void Eat()
	{
		Hunger += 20;
	}
}
