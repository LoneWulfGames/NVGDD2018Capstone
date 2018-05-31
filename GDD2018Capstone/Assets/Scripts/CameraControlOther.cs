using UnityEngine;

public class CameraControlOther : MonoBehaviour
{
    public Vector2 mouseLook;
    private Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    //person we are seeing through
    public GameObject mob;
    public Vector3 offSetFromMob;
    public float tiltMin, tiltMax;

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            return;
        }

        //get mouse direction
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        //smooth mouse direction
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook = new Vector2(mouseLook.x, Mathf.Clamp(mouseLook.y, tiltMin, tiltMax));

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        if (mob != null)
            mob.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, mob.transform.up);
    }

    public void ResetCam()
    {
        print("setting camera up!");    
        transform.SetParent(mob.transform);
        //transform.position=(mob.transform.position+ Vector3.up);
        transform.position = mob.transform.position + offSetFromMob;
    }
}