using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;

    private float _frequency = 1.0f;
    private Coroutine _spawnCoroutine;

    private void Start()
    {
        StartCoroutine(ObjectSpawning());
    }

    public void SetSpeed(string value)
    {
        if (!int.TryParse(value, out var result))
            return;

        foreach (var item in ObjectPool.instance.GetPooledObjects())
        {
            item.Speed = result;
        }
    }

    public void SetDistance(string value)
    {
        if (!int.TryParse(value, out var result))
            return;

        foreach (var item in ObjectPool.instance.GetPooledObjects())
        {
            item.Distance = result;
        }
    }

    public void SetFrequency(string value)
    {
        if (!int.TryParse(value, out var result))
            return;

        _frequency = result;
    }

    private IEnumerator ObjectSpawning()
    {
        while (true)
        {
            var newObject = ObjectPool.instance.GetPooledObject();
            newObject.transform.position = _startPosition.position;
            newObject.gameObject.SetActive(true);

            yield return new WaitForSeconds(_frequency);
        }
    }
}
