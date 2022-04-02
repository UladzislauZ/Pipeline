using System.Collections;
using UnityEngine;

public class FailedStar : MonoBehaviour
{
    [SerializeField] private Transform _finalPosition;
    [SerializeField] private float _speed = 200;
    
    private bool _onMoveStar;
    private Vector3 _startPosition;
    private Transform transformStar;
    
    void Start()
    {
        transformStar = transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_onMoveStar)
        {
            _onMoveStar = true;
            StartCoroutine(StartFailing());
        }
    }

    private IEnumerator StartFailing()
    {
        _startPosition = transformStar.position;
        var direction = _finalPosition.position - _startPosition;
        direction.Normalize();
        gameObject.GetComponent<TrailRenderer>().enabled = true;
        while (Vector3.Distance(transformStar.position, _finalPosition.position)>5f)
        {
            transform.Translate(direction * _speed * Time.deltaTime);
            yield return null;
        }

        gameObject.GetComponent<TrailRenderer>().enabled = false;
        transformStar.position = _startPosition;
        _onMoveStar = false;
    }
}
