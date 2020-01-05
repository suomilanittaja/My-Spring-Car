using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
	public GameObject engine;
	public bool engine2;
	public GameObject engine3;
	
	public void Start()
	{
		 engine = GameObject.Find("engine");


	}		
   void OnTriggerEnter (Collider Hit)
	{
		if (Hit.gameObject == engine)
		{
			engine2 = true;
			engine.gameObject.SetActive(false);
			engine3.gameObject.SetActive(true);
		}
			
	}
	
}
