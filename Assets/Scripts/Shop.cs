﻿using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour
{
   [SerializeField] private string Item1 = "Selectable";
   [SerializeField] private string Item2 = "Selectable";
   public GameObject Text;
   public GameObject Item;
   private Transform _selection;
   public Vector3 Buyed;
   public Money money; 
   public int money2;
   public Drink drink;
   public Eat eat;
   
   private void Update()
   {
	   money2 = money.money;
	  
	   
	   //Check if ray dont touch it anymore
	   if (_selection != null)
	   {
		   _selection = null;
		   Text.gameObject.SetActive(false);
	   }
	   
	   //Creating a Ray
	   var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f, 0f));
	   RaycastHit hit;
	   
	   //Check if ray touch it 
	   if (Physics.Raycast(ray, out hit))
	   {
		   var selection = hit.transform;
		   Item = hit.collider.gameObject;
		   
		   if (selection.CompareTag(Item1) && Input.GetKeyDown(KeyCode.F) && money2 >= 10)
		   {
				money.money -= 10;
				Vector3 position = Buyed;
				Item.transform.position = position;
				drink.enabled = false;
				Item.tag = "Beer";
				StartCoroutine(Time());
				 
		   }
		   if (selection.CompareTag(Item2) && Input.GetKeyDown(KeyCode.F) && money2 >= 20)
		   {
				money.money -= 20;
				Vector3 position = Buyed;
				Item.transform.position = position;
				eat.enabled = false;
				Item.tag = "Food";
				StartCoroutine(Time());
				 
		   }
			
		   if (selection.CompareTag(Item1) | selection.CompareTag(Item2))
		   {  
				Text.gameObject.SetActive(true);
				_selection = selection;
		   }
	   }
	   
   } 
   IEnumerator Time()
	{
			
		yield return new WaitForSeconds(1);
		drink.enabled = true;
		eat.enabled = true;
	}
   
}