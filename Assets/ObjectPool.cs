using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [HideInInspector] public static ObjectPool instance;

    [SerializeField] private Transform _parent;
    [SerializeField] private int _amountOfObjects = 20;
    [SerializeField] private GameObject _prefab;

    private List<MovingObject> _pooledObjects = new List<MovingObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        for (int i = 0; i < _amountOfObjects; i++)
        {
            AddNewObject();
        }
    }

    public MovingObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].gameObject.activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        return AddNewObject();
    }

    public List<MovingObject> GetPooledObjects()
    {
        return _pooledObjects;
    }

    private MovingObject AddNewObject()
    {
        MovingObject obj = Instantiate(_prefab.gameObject, _parent).GetComponent<MovingObject>();
        obj.gameObject.SetActive(false);
        _pooledObjects.Add(obj);

        return obj;
    }

}
