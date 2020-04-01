using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeWeapon : MonoBehaviour
{
	[SerializeField] private string selectableTag = "Selectable";
	private Transform _selection;
	public GameObject Text;
	public GameObject Axe;
	public GameObject pickAxe;
	public bool picked;
	public bool Hit = false;
  public Animator anim;
	public GameObject blade;
	public Transform theDest;
	public GameObject pickAxe2;
	public Raycast rayScript;

	void Start()
	{
		Axe.gameObject.SetActive(false);
	}

	private void Update()
   {
		 if (rayScript.rayHitted.CompareTag(selectableTag) && Input.GetKeyDown(KeyCode.F) && rayScript.hitDis <= 5)
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

		 }

		 if (rayScript.rayHitted.CompareTag(selectableTag) && rayScript.hitDis <= 5)
		 {
			Text.gameObject.SetActive(true);
		 }
		 else
		 	Text.gameObject.SetActive(false);

	   if (picked == true && Input.GetMouseButtonDown(0))
		   {
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
		Text.gameObject.SetActive(false);
	}

}
