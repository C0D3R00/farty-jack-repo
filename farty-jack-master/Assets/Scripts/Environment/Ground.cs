using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Ground : MonoBehaviour
{
    private AudioSource
        _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(GameManager.Instance.State == GameStates.PLAY)
            _audioSource.Play();
    }
}
