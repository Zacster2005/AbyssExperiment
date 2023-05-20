using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShake : MonoBehaviour 
{
    public GameObject Cam;

    public bool IsShake = false;


    public IEnumerator Shake(float duration, float magnitude)
    {
        if(!IsShake)
        {
            IsShake = true;

            Vector3 originalPos = transform.localPosition;

            


            float elapsed = 0.0f;

            while (elapsed < duration)
            {

                float y = Random.Range(-.25f, .25f);

                transform.localPosition = new Vector3(originalPos.x, y, originalPos.z);

                yield return null;

                IsShake = false;
            }

            transform.localPosition = originalPos;
         
        }
        
        
    }


}//class
