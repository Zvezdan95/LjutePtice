using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;

    bool _alive = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_alive) return;

        string[] deathColiders = { "Player", "Ground" };
        bool deathCollision = System.Array.Exists(deathColiders, s => s == collision.gameObject.tag);

        if (deathCollision) StartCoroutine("Die");
    }

    IEnumerator Die()
    {
        _alive = false;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();

        yield return new WaitForSeconds(2);

        gameObject.SetActive(false);
    }
}
