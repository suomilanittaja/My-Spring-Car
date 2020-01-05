using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterandExit : MonoBehaviour
{
    public CarControll carControll;
	public GameObject text;
	public GameObject text2;
	public GameObject player;
	public GameObject Car;
	public bool enter;
	public Transform Exit;
	public Transform PLayer;
	public Engine engine;
	
	void OnTriggerExit (Collider other)
	{
		text.gameObject.SetActive(false);
		enter = false;
		text2.gameObject.SetActive(false);
	}
	
	void OnTriggerEnter (Collider Hit)
	{
		if (Hit.gameObject == player)
		{
			if (engine.engine2 == true)
			{
				text.gameObject.SetActive(true);
				enter = true;
			}
			else if (engine.engine2 == false)
			{
				text2.gameObject.SetActive(true);
			}
		}
			
	}
	void Update()
	{
		if (enter == true && Input.GetKeyDown(KeyCode.Return))
		{
			print("rte");
			carControll.enabled = true;
			player.gameObject.SetActive(false);
			print("drive");
			StartCoroutine(Time2());
			text.gameObject.SetActive(false);
		}
		
		if (enter == false && Input.GetKeyDown(KeyCode.Return))
		{
			carControll.enabled = false;
			player.gameObject.SetActive(true);
			enter = false;
			PLayer.transform.position = Exit.transform.position;
		}
			
	}
	IEnumerator Time2()
	{	
		yield return new WaitForSeconds(1);
		enter = false;
		
	}
}
