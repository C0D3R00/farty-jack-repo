using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Ceiling : MonoBehaviour
{
    private AudioSource
        _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audioSource.Play();
    }
}
