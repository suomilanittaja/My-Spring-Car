using UnityEngine;
using System.Collections;

   public class OpenDoor : MonoBehaviour
    {
        public bool open = false;
        Animator anim;
     
        void Start ()
        {
            anim = GetComponentInChildren<Animator> ();
            Debug.Log("GOT THE ANIMATOR");
        }
     
        void OnTriggerEnter (Collider other)
     
            {
            if (other.CompareTag("Player"))
            {
                anim.SetBool ("open", true);
                Debug.Log ("OPENING THE DOOR");
            }
     
        }
     
        void OnTriggerExit (Collider other)
     
            {
            if (other.CompareTag("Player"))
            {
                anim.SetBool ("open", false);
                Debug.Log ("OPENING THE DOOR");
            }
        }

    }
