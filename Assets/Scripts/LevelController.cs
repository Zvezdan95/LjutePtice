using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject _levelEndMenu;

    Monster[] _monsters;
    bool _levelEnd = false;

    void OnEnable()
    {
        _levelEndMenu.SetActive(false);
        _monsters = FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_levelEnd) return;

        if (_monsters.All(monster => !monster.gameObject.activeSelf))
        {
            _levelEnd = true;
            _levelEndMenu.SetActive(true);
        }
    }
}
