using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
	[SerializeField] private string selectableTag = "Selectable";
	[SerializeField] private string selectableTag2 = "Selectable";
	[SerializeField] private string selectableTag3 = "Selectable";


	 private Transform _selection;
   private GameObject PickUP;
   public Transform theDest;
   public bool picked;
   public GameObject lastPick;
   public Raycast rayScript;

   private void Start()
   {
	   picked = false;
   }

   private void Update()
   {
		 PickUP = rayScript.rayHitted;
		 if (rayScript.rayHitted.CompareTag(selectableTag) && Input.GetMouseButtonDown(0) && picked == false)
		 {
		 lastPick = rayScript.rayHitted;
		 MouseDown();
		 print("key was pressed");
		 }
		 if (rayScript.rayHitted.CompareTag(selectableTag2) && Input.GetMouseButtonDown(0) && picked == false)
		 {
		 lastPick = rayScript.rayHitted;
		 MouseDown();
		 print("key was pressed");
		 }

		 if (rayScript.rayHitted.CompareTag(selectableTag3) && Input.GetMouseButtonDown(0) && picked == false)
		 {
		 lastPick = rayScript.rayHitted;
		 MouseDown();
		 print("key was pressed");
		 }


		 if (Input.GetMouseButtonUp(0))
		 {
		 MouseUp();
		 print("key was pressed");
		 }
   }


	void MouseDown()
	{
		PickUP.GetComponent<Rigidbody>().isKinematic = true;
		PickUP.GetComponent<Rigidbody>().useGravity = false;
		PickUP.transform.position = theDest.position;
		PickUP.transform.parent = GameObject.Find("Destination").transform;
		picked = true;
	}

	void MouseUp()
	{
		picked = false;
		lastPick.GetComponent<Rigidbody>().isKinematic = false;
		lastPick.transform.parent = null;
		lastPick.GetComponent<Rigidbody>().useGravity = true;
	}
}
