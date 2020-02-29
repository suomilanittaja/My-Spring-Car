using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RVP;

public class CarCrash : MonoBehaviour
{
  public float s;
  public Collider Sensor;
  public VehicleParent vp;
  public PlayerStats Health;
  public GameObject camera;
  public GameObject settings;
  public bool Died = false;

    void Start()
    {
      settings.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
      s = (vp.velMag * 2.23694f);
      if (Died == true)
      {
        camera.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        Health.Health -= 100;
        print ("died");
      }
    }
    void OnCollisionEnter()
    {
      if (s > 50)
      {
        StartCoroutine(Timer1());
      }
    }
    IEnumerator Timer1()
    {
      yield return new WaitForSeconds(3);
      Died = true;
    }
}
