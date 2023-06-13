using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public float GameTime;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (PlayerStats.Collectibles == 6)
        {
            Win();
        }
        if (GameTime < 0)
        {
            Lose();
        }

    }

    private void FixedUpdate()
    {
        GameTime -= 1f * Time.deltaTime;
    }

    void Lose()
    {

    }

    void Win()
    {

    }
}//class
