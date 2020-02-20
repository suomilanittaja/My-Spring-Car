using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
   [SerializeField] private string selectableTag = "Selectable";

   private Transform _selection;
   public PlayerStats stats;
   public GameObject Text;
   private GameObject Food;
   public Raycast rayScript;

   private void Update()
   {
	   Food = rayScript.rayHitted;
     if (rayScript.rayHitted.CompareTag(selectableTag) && Input.GetKeyDown(KeyCode.F))
     {
     stats.Eat();
     print("key was pressed");
     Food.gameObject.SetActive(false);
     }

     if (rayScript.rayHitted.CompareTag(selectableTag))
     {
      Text.gameObject.SetActive(true);
     }
     else
      Text.gameObject.SetActive(false);
   }
}
