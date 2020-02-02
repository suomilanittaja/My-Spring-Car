using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
	public GameObject Log;
	private Log logScript;
	public bool Disabled;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        Spawn();
		Disabled = true;
    }
	void Update()
	{
		Spawn();
	}
	
	void Spawn()
	{
		if(Disabled == true)
		{
			Disabled = false;
			StartCoroutine(Time2());
		}
	}
	IEnumerator Time2()
	{	
		yield return new WaitForSeconds(1);
		Instantiate(Log, new Vector3(14, 1, 7), Quaternion.identity);
		
	}
}
