using UnityEngine;
using System.Collections;

   public class OpenDoor : MonoBehaviour
    {
        public bool open = false;
        public Animator anim;
        private bool Pressed;
        public GameObject textOpen;
        public GameObject textClose;


        void Update ()
        {
            if (Input.GetKeyDown(KeyCode.O))
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

        void OnTriggerEnter (Collider other)
        {
            if (other.CompareTag("Player") && open == false)
            {
                textOpen.gameObject.SetActive(true);
                textClose.gameObject.SetActive(false);
            }
            else if (other.CompareTag("Player") && open == true)
            {
                textOpen.gameObject.SetActive(false);
                textClose.gameObject.SetActive(true);
            }
        }

        void OnTriggerExit (Collider other)
        {
            textOpen.gameObject.SetActive(false);
            textClose.gameObject.SetActive(false);
        }
    }
