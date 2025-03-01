using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConstants.win_area))
        {
            GameEvent.OnEndLevel?.Invoke(EndLevelType.Win);
            Debug.Log("Win");
            gameObject.SetActive(false);
        }
        else if (other.CompareTag(GameConstants.dead_zone))
        {
            GameEvent.OnEndLevel?.Invoke(EndLevelType.Lose);
            Debug.Log("Lose");
            //gameObject.SetActive(false);
        }
        else if (other.CompareTag(GameConstants.moving_platform))
        {
            if(other.transform.parent.TryGetComponent(out MovingPlatform movingPlatform))
            {
                movingPlatform.MoveToPosition();
                other.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }
}
