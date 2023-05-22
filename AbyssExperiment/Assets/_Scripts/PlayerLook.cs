using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public static float mouseSens = 500f;

    public Transform PlayerBody;

    public static float  Xrotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        
    }

  

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSens; 
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSens;

        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);




    }//Update

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {

            float y = Random.Range(-.25f, .25f);

            transform.localPosition = new Vector3(originalPos.x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;

    }

}//class
