using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour
{
   [SerializeField] private string Item1 = "Selectable";
   [SerializeField] private string Item2 = "Selectable";
   public GameObject Text;
   public GameObject Item;
   private Transform _selection;
   public Vector3 Buyed;
   public Money money;
   public int money2;
   public Drink drink;
   public Eat eat;
   public Raycast rayScript;

   private void Update()
   {
	   money2 = money.money;

     Item = rayScript.rayHitted;

     if (rayScript.rayHitted.CompareTag(Item1) && Input.GetKeyDown(KeyCode.F) && money2 >= 10)
     {
      money.money -= 10;
      Vector3 position = Buyed;
      Item.transform.position = position;
      drink.enabled = false;
      Item.tag = "Beer";
      StartCoroutine(Time());

     }
     if (rayScript.rayHitted.CompareTag(Item2) && Input.GetKeyDown(KeyCode.F) && money2 >= 20)
     {
      money.money -= 20;
      Vector3 position = Buyed;
      Item.transform.position = position;
      eat.enabled = false;
      Item.tag = "Food";
      StartCoroutine(Time());

     }

     if (rayScript.rayHitted.CompareTag(Item1) | rayScript.rayHitted.CompareTag(Item2))
     {
      Text.gameObject.SetActive(true);
     }
     else
      Text.gameObject.SetActive(false);
   }
   IEnumerator Time()
	{

		yield return new WaitForSeconds(1);
		drink.enabled = true;
		eat.enabled = true;
	}
}
