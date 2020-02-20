using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCameraController : MonoBehaviour {

    [SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    public float smoothing = 2.0f;
    // the chacter is the capsule
    public GameObject character;
    // get the incremental value of mouse moving
    private Vector2 mouseLook;
    // smooth the mouse moving
    private Vector2 smoothV;

    public bool cursor = true;

	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked; //lock cursor
        Cursor.visible = false; //disable visible mouse
	}

	// Update is called once per frame
	void Update () {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // the interpolated float result between the two float values
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        // incrementally add to the camera look
        mouseLook += smoothV;

        // vector3.right means the x-axis
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
        //Cursor key toggle
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; //unlock cursor
            Cursor.visible = true; //make mouse visible
        }
    }
 public void Lock ()
  {
      Cursor.lockState = CursorLockMode.Locked; //lock cursor
      Cursor.visible = false; //disable visible mouse
  }
}
