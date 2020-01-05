using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBricks : MonoBehaviour
{
	public GameObject SellPoint;
	public Money money;
	public GameObject money2;
	
	public void Start()
	{
		 SellPoint = GameObject.Find("SellPoint");
		 money2 = GameObject.Find("Manager");
			money = money2.GetComponent<Money>();

	}		
   void OnTriggerEnter (Collider Hit)
	{
		if (Hit.gameObject == SellPoint)
		{
			money.money += 20;
			Destroy(gameObject);
			
		}
			
	}
}
