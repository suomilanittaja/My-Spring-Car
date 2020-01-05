using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeWeapon : MonoBehaviour
{
	[SerializeField] private string selectableTag = "Selectable";
	private Transform _selection;
	public GameObject Text;
	public float hitDis;
	public GameObject Axe;
	public GameObject pickAxe;
	public bool picked;
	public bool Hit = false;
    public Animator anim;
	public GameObject blade;
	public Transform theDest;
	public GameObject pickAxe2;
	
	void Start()
	{
		Axe.gameObject.SetActive(false);
	}
	
	private void Update()
   {
	   
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
		   hitDis = hit.distance;
		   var selection = hit.transform;
		   pickAxe = hit.collider.gameObject;
		   if (selection.CompareTag(selectableTag) && Input.GetKeyDown(KeyCode.F) && hitDis <= 3)
		   {
			 print("key was pressed");
			 pickAxe.gameObject.SetActive(false);
			 Axe.gameObject.SetActive(true);
			 StartCoroutine(Time3());
		   }
		   if (picked == true && Input.GetKeyDown(KeyCode.F))
		   {
			 print("key was pressed34");
			 pickAxe2.gameObject.SetActive(true);
			 Axe.gameObject.SetActive(false);
			 picked = false;
			 pickAxe2.transform.position = theDest.position;
			 //pickAxe.transform.parent = GameObject.Find("Destination").transform;
		   }
			
		   if (selection.CompareTag(selectableTag)  && hitDis <= 3)
		   {  
				Text.gameObject.SetActive(true);
				_selection = selection;
		   }
	   }
	   if (picked == true && Input.GetMouseButtonDown(0))
		   {

			 //MouseDown();
			 print("key was pressed");
			 anim.SetBool ("Hit", true);
			 blade.gameObject.SetActive(true);
			 StartCoroutine(Time2());
		   }
   }  
   IEnumerator Time2()
	{	
		yield return new WaitForSeconds(1);
		anim.SetBool ("Hit", false);
		blade.gameObject.SetActive(false);
	}
	 IEnumerator Time3()
	{	
		yield return new WaitForSeconds(1);
		picked = true;
	}
   
}
