using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Dive : BehaviourAbstract
{
    [SerializeField]
    private Transform
        _bird;

    [SerializeField]
    private float
        _startAngle = 15f,
        _endAngle = -90f,
        _timeToDive = .5f;

    private Coroutine
        _diveCo;

    private float
        _startPositionY = 0f;

    protected override void Update()
    {
        if(_inputState.CurrentState == InputTypes.TAP)
        {
            _startPositionY = transform.position.y;

            if (_diveCo != null)
                StopCoroutine(_diveCo);

            _diveCo = StartCoroutine(DiveCo());
        }
    }

    private IEnumerator DiveCo()
    {
        var timer = 0f;
        var startAngle = transform.rotation.eulerAngles.z;

        //while(timer < _timeToDive)
        //{
        //    timer += Time.deltaTime;
        //    _bird.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Lerp(startAngle, _startAngle, timer / _timeToDive)));

        //    yield return null;
        //}

        _bird.rotation = Quaternion.Euler(new Vector3(0f, 0f, _startAngle));

        yield return new WaitForSeconds(.5f);

        while (timer < _timeToDive)
        {
            timer += Time.deltaTime;
            _bird.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Lerp(_startAngle, _endAngle, timer / _timeToDive)));

            yield return null;
        }
    }
}
