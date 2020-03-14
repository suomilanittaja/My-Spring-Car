using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Drink : MonoBehaviour
{
   [SerializeField] private string selectableTag = "Selectable";

   private Transform _selection;
   public PlayerStats stats;
   public GameObject Text;
   private GameObject Beer;
   public Raycast rayScript;



   void Start()
   {

   }

   private void Update()
   {
     Beer = rayScript.rayHitted;
     if (rayScript.rayHitted.CompareTag(selectableTag) && Input.GetKeyDown(KeyCode.F))
     {
     stats.Drink();
     print("key was pressed");
     Beer.gameObject.SetActive(false);
     }

     if (rayScript.rayHitted.CompareTag(selectableTag))
     {
      Text.gameObject.SetActive(true);
     }
     else
      Text.gameObject.SetActive(false);
   }
}
