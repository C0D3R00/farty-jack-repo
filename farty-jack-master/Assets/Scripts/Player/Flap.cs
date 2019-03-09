using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Flap : BehaviourAbstract
{
    [SerializeField]
    private AudioClip
        _flapClip;

    [SerializeField]
    private float
        _velocityY = 10f;

    private bool
        _isStatic = true;

    protected override void Update()
    {
        if ((GameManager.Instance.State == GameStates.TUTORIAL || GameManager.Instance.State == GameStates.PLAY) &&
            _inputState.CurrentState == InputTypes.TAP)
        {
            if (_isStatic)
            {
                _isStatic = false;

                _rb2d.isKinematic = false;
                _rb2d.gravityScale = 1f;
            }

            _rb2d.velocity = Vector2.zero;
            _rb2d.AddForce(new Vector2(0f, _velocityY), ForceMode2D.Impulse);

            _audioSource.PlayOneShot(_flapClip);
        }
    }
}
