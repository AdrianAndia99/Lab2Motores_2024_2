using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    public void PlayTime()
    {
        Time.timeScale = 1.0f;
    }
}
