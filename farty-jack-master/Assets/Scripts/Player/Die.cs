using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Die : BehaviourAbstract
{
    [SerializeField]
    private AudioClip
        _dieClip;

    private bool
        _isDead = false;

    protected override void Update()
    {
        if (_collisionState.HitType != CollisionTypes.NONE &&
            !_isDead)
        {
            _isDead = true;

            if(_collisionState.HitType == CollisionTypes.COLUMN || _collisionState.HitType == CollisionTypes.CEILING)
                _audioSource.PlayOneShot(_dieClip);
        }
    }
}
