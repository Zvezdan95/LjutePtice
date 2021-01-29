using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float _launchForce = 500;
    [SerializeField] float _maxDragDistance = 1.5F;

    Vector2 _startPosition;
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = _rigidbody2D.position;

        _rigidbody2D.isKinematic = true;
    }

    void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
    }

    void OnMouseUp()
    {
        var currentPosition = _rigidbody2D.position;
        var direction = _startPosition - currentPosition;
        direction.Normalize();

        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction * _launchForce);

        _spriteRenderer.color = Color.white;
    }

    void OnMouseDrag()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPositon = mousePosition;

        var distance = Vector2.Distance(desiredPositon, _startPosition);

        if (distance > _maxDragDistance)
        {
            var direction = (desiredPositon - _startPosition).normalized;

            desiredPositon = _startPosition + direction * _maxDragDistance;
        }

        if (mousePosition.x > _startPosition.x)
        {
            desiredPositon.x = _startPosition.x;
        }

        _rigidbody2D.position = desiredPositon;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine("ResetAfterDelay");
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        _rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
