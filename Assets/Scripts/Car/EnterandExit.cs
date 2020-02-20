using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RVP;

public class EnterandExit : MonoBehaviour
{
  public BasicInput carControll;
	public GameObject text;
	public GameObject player;
	public bool enter;
	public Transform Exit;
	public Transform playerPos;
	public GameObject Camera;
	public GameObject carUI;

	void OnTriggerExit (Collider other)
	{
		text.gameObject.SetActive(false);
		enter = false;
	}

	void OnTriggerEnter (Collider Hit)
	{
		if (Hit.gameObject == player)
		{
				text.gameObject.SetActive(true);
				enter = true;
		}

	}
	void Update()
	{
		if (enter == true && Input.GetKeyDown(KeyCode.Return))
		{
			carControll.enabled = true;
			Camera.gameObject.SetActive(true);
			player.gameObject.SetActive(false);
			StartCoroutine(Time2());
			text.gameObject.SetActive(false);
			carUI.gameObject.SetActive(true);
		}

		if (enter == false && Input.GetKeyDown(KeyCode.Return))
		{
			carControll.enabled = false;
      playerPos.transform.position = Exit.transform.position;
			player.gameObject.SetActive(true);
			enter = false;
			Camera.gameObject.SetActive(false);
			carUI.gameObject.SetActive(false);
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
