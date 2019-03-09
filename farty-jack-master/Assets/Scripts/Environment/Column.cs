using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Column : MonoBehaviour
{
    [SerializeField]
    private List<BoxCollider2D>
        _boxColliders2d;

    [SerializeField]
    private AudioClip
        _hitClip,
        _pointClip;

    private AudioSource
        _audioSource;

    private bool
        _isDead = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (transform.position.x < -ResolutionManager.CameraFullWidth)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" &&
            !_isDead)
        {
            _audioSource.PlayOneShot(_pointClip);

            EventManager.Instance.TriggerEvent(ActionNames.PASSED_COLUMN.ToString());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" &&
            !_isDead)
        {
            _audioSource.PlayOneShot(_hitClip);
            _isDead = true;

            foreach (var boxCollider in _boxColliders2d)
                boxCollider.enabled = false;
        }
    }
}
