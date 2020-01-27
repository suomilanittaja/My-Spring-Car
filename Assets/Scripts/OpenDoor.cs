using UnityEngine;
using System.Collections;

   public class OpenDoor : MonoBehaviour
    {
        public bool open = false;
        Animator anim;
        private bool Pressed;
        void Start ()
        {
            anim = GetComponentInChildren<Animator> ();
            Debug.Log("GOT THE ANIMATOR");
        }

        void Update ()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Pressed = true;
            }
            else 
                Pressed = false;
        }
     
        void OnTriggerStay (Collider other)
     
            {
            if (other.CompareTag("Player") && Pressed == true && open == false)
            {
                open = true;
                anim.SetBool ("open", true);
                Debug.Log ("OPENING THE DOOR");
            }
            else if (other.CompareTag("Player") && Pressed == true && open == true)
            {
                open = false;
                anim.SetBool ("open", false);
                Debug.Log ("Closing THE DOOR");
            }
     
        }

    }
