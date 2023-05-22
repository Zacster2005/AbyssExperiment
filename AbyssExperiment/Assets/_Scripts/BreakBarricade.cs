using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBarricade : MonoBehaviour
{

    public static GameObject Hit;
    // Start is called before the first frame update
    public static void Destroy()
        {
            Destroy(Hit);
        }
}//class
