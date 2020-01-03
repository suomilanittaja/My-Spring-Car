using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
   [SerializeField] private Material highlightMaterial;
   [SerializeField] private string selectableTag = "Selectable";
   [SerializeField] private Material defaultMaterial;
   public GameObject Text;
   public DrunkTimer DrunkTimer;
   public GameObject Beer;
   private Transform _selection;
   
   public PlayerStats stats;
   
   private void Update()
   {
	   
	   
	   //Check if ray dont touch it anymore
	   if (_selection != null)
	   {
		   var selectionRenderer = _selection.GetComponent<Renderer>();
		   selectionRenderer.material = defaultMaterial;
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
		   Beer = hit.collider.gameObject;
		   if (selection.CompareTag(selectableTag) && Input.GetKeyDown(KeyCode.F))
		   {
			 stats.Drink();
			 DrunkTimer.enabled = true;
			 print("key was pressed");
			 Beer.gameObject.SetActive(false);
		   }
			
		   if (selection.CompareTag(selectableTag))
		   {
			    var selectionRenderer = selection.GetComponent<Renderer>();
				Text.gameObject.SetActive(true);
				
				
				if (selectionRenderer != null)
				{
					selectionRenderer.material = highlightMaterial;
					
				}
				_selection = selection;
		   }
  
	   }
   }
   
}
