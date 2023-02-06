using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShake : MonoBehaviour {



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
