using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
	public GameObject block;
	public GameObject Axe;
	public Money money;
	public GameObject money2;
	public LogManager log;
	public GameObject log2;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
		log2 = GameObject.FindGameObjectWithTag("Log");
		log = log2.GetComponent<LogManager>();
		money2 = GameObject.Find("Manager");
		money = money2.GetComponent<Money>();
        Axe = GameObject.FindGameObjectWithTag("Axe");
    }
	
	void OnTriggerEnter (Collider Hit)
	{
		if (Hit.gameObject == Axe)
		{
			money.money += 1;
			this.gameObject.SetActive(false);
			disabled2();
			log.Disabled = true;
		}
			
	}
	
	void disabled2()
	{
		Instantiate(block, new Vector3(14, 1, 8), Quaternion.identity);
		Instantiate(block, new Vector3(14, 1, 6), Quaternion.identity);
	}

}
