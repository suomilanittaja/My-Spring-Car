using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
	public int money;
	public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        money = 100;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = money.ToString() + "€";
    }
}
