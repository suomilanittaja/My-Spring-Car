using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarParts : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
	
	private Transform _selection;
   public GameObject PickUP;
   public Transform theDest;
   public bool picked;
   public GameObject lastPick;
   public float hitDis;
   
   private void Start()
   {
	   picked = false;
   }
   
   private void Update()
   {
	   
	   //Check if ray dont touch it anymore
	   if (_selection != null)
	   {
		   _selection = null;
	   }
	   
	   //Creating a Ray
	   var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f, 0f));
	   RaycastHit hit;
	   
	
	   //Check if ray touch it 
	   if (Physics.Raycast(ray, out hit))
	   {
		   hitDis = hit.distance;
		   var selection = hit.transform;
		   PickUP = hit.collider.gameObject;
		   if (selection.CompareTag(selectableTag) && Input.GetMouseButtonDown(0) && picked == false && hitDis <= 3)
		   {
			 lastPick = hit.collider.gameObject;
			 MouseDown();
			 print("key was pressed");
			 
		   }
		   
		   
		   if (Input.GetMouseButtonUp(0))
		   {
			 MouseUp();
			 print("key was pressed");
		   }
		   
			
		   if (selection.CompareTag(selectableTag) && hitDis <= 3)
		   {  
				_selection = selection;
		   }
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
