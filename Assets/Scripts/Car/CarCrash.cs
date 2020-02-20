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

    void Start()
    {
      settings.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
      s = (vp.velMag * 2.23694f);
    }
    void OnCollisionEnter()
    {
      if (s > 50)
      {
        camera.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        Health.Health -= 100;
        print ("died");
      }
    }
}
