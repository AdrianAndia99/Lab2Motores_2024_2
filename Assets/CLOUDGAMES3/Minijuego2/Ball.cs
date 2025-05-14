using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public static event Action OnDefeat;
    [SerializeField] private AudioSource soundB;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Dead"))
        {
            OnDefeat?.Invoke();
        }
        if (collision.collider.CompareTag("Platform"))
        {
            soundB.PlayOneShot(soundB.clip);
        }
    }
}