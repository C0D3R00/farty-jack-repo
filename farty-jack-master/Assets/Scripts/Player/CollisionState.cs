using UnityEngine;

using System.Collections;

public class CollisionState : MonoBehaviour
{
    public CollisionTypes HitType { get; private set; }

    private bool
        _isDead = false;

    private void Start()
    {
        HitType = CollisionTypes.NONE;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isDead)
        {
            _isDead = true;

            switch (collision.collider.tag)
            {
                case "COLUMN":
                    HitType = CollisionTypes.COLUMN;

                    break;
                case "GROUND":
                    HitType = CollisionTypes.GROUND;

                    break;
                case "CEILING":
                    HitType = CollisionTypes.CEILING;

                    break;
            }

            EventManager.Instance.TriggerOnUpdateState(GameStates.GAME_OVER);
            EventManager.Instance.TriggerOnUpdatePreviousScreenHidden(false);
        }
    }
}
