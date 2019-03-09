using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class ColumnsManager : Singleton<ColumnsManager>
{
    [SerializeField]
    private int
        _columnIntervalInUnits = 6,
        _columnCount = 5;

    [SerializeField]
    private float
        _minY = -4f,
        _maxY = 4f;

    [SerializeField]
    private ScrollingObject
        _scrollingObject;

    private float
        _currentPositionX = 0f;

    private void Start()
    {
        _currentPositionX = _columnIntervalInUnits * 2f;

        // init
        InitColumns();
    }

    private void OnEnable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.StartListening(ActionNames.START_GAME.ToString(), StartGame);
            EventManager.Instance.StartListening(ActionNames.PASSED_COLUMN.ToString(), SpawnColumn);
        }
    }

    private void OnDisable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.StopListening(ActionNames.START_GAME.ToString(), StartGame);
            EventManager.Instance.StopListening(ActionNames.PASSED_COLUMN.ToString(), SpawnColumn);
        }
    }

    //private void Update()
    //{
    //    if(GameManager.Instance.State == GameStates.PLAY)
    //    {
    //        var positionX = Mathf.FloorToInt(transform.position.x);
    //        var isMod = positionX % 6 == 0;

    //        Debug.Log(positionX + " isMod: " + isMod);

    //        if (isMod)
    //        {
    //            var column = ObjectPooler.Instance.GetPooledObject(ObjectPoolType.COLUMN);

    //            column.transform.SetParent(transform);
    //            column.transform.localPosition = new Vector3(_currentPositionX, Random.Range(_minY, _maxY), 0f);

    //            _currentPositionX += _columnIntervalInUnits;
    //        }
    //    }
    //}

    private void StartGame()
    {
        _scrollingObject.enabled = true;
    }

    private void InitColumns()
    {
        for (var i = 0; i < _columnCount; i++)
            SpawnColumn();
    }

    private void SpawnColumn()
    {
        var column = ObjectPooler.Instance.GetPooledObject(ObjectPoolType.COLUMN);

        column.transform.SetParent(transform);
        column.transform.localPosition = new Vector3(_currentPositionX, Random.Range(_minY, _maxY), 0f);

        _currentPositionX += _columnIntervalInUnits;
    }
}
