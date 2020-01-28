using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RVP;

public class EnterandExit : MonoBehaviour
{
    public  BasicInput carControll;
	public GameObject text;
	public GameObject text2;
	public GameObject player;
	public bool enter;
	public Transform Exit;
	public Transform playerPos;
	public Engine engine;
	public GameObject Camera;
	
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
			Camera.gameObject.SetActive(true);
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
			Camera.gameObject.SetActive(false);
			playerPos.transform.position = Exit.transform.position;
		}
			
	}
	IEnumerator Time2()
	{	
		yield return new WaitForSeconds(1);
		enter = false;
		
	}

	void Start ()
	{
		Camera.gameObject.SetActive(false);
		carControll.enabled = false;
	}
}
