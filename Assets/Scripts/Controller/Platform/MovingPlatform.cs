using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    [SerializeField] Transform targetPosition;
    private Vector3 initialPosition;

    [SerializeField] private BoxCollider collid;
    private void Awake()
    {
        initialPosition = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = initialPosition;
        collid.isTrigger = true;
    }

    public void MoveToPosition()
    {
        StartCoroutine(MoveSmoothly(targetPosition.position));
    }

    private IEnumerator MoveSmoothly(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
            yield return null;
        }
        transform.position = target;
    }
}
