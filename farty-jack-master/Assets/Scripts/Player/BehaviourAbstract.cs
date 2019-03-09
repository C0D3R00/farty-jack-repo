using UnityEngine;

public abstract class BehaviourAbstract : MonoBehaviour
{
    protected Rigidbody2D
        _rb2d;

    protected Animator
        _animator;

    protected InputState
        _inputState;

    protected CollisionState
        _collisionState;

    protected AudioSource
        _audioSource;

    protected virtual void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _inputState = GetComponent<InputState>();
        _collisionState = GetComponent<CollisionState>();
        _audioSource = GetComponent<AudioSource>();
    }

    protected virtual void Start() { }

    protected virtual void Update() { }

    protected virtual void OnEnable() { }

    protected virtual void OnDisable() { }
}
