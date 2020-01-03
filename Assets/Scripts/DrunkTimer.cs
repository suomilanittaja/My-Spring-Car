using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkTimer : MonoBehaviour
{
	public Drunk DrunkScript;
	
	void Start()
    {
        StartCoroutine(DoSomething());
    }
	
    IEnumerator DoSomething()
    {
         DrunkScript.enabled = true;
         yield return new WaitForSeconds(60);
         DrunkScript.enabled = false;
	}
}
