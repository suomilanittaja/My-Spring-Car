using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
   public Transform _selection;
   public GameObject Text;
   public float hitDis;
   public GameObject rayHitted;

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
       rayHitted = hit.collider.gameObject;
	   }
   }
}
