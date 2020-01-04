using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
   [SerializeField] private string selectableTag = "Selectable";

   private Transform _selection;
   
   public PlayerStats stats;
   
   public GameObject Text;
   public GameObject Food;
   
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
		   var selection = hit.transform;
		   Food = hit.collider.gameObject;
		   if (selection.CompareTag(selectableTag) && Input.GetKeyDown(KeyCode.F))
		   {
			 stats.Eat();
			 print("key was pressed");
			 Food.gameObject.SetActive(false);
		   }
			
		   if (selection.CompareTag(selectableTag))
		   {
				Text.gameObject.SetActive(true);
				_selection = selection;
		   }
	   }
   }
}
