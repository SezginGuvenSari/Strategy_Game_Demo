using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    #region Struct

    [System.Serializable]
    public struct MyPool
    {
        public List<GameObject> Pool;
        public GameObject ObjectPrefab;
        public int PoolSize;
        public ObjectTypes ObjectTypes;
    }

    #endregion

    #region Serialize

    [SerializeField] private MyPool[] _pools;

    [SerializeField] private Transform _uiTransform;

    [SerializeField] private Transform _objectTransform;


    #endregion

    #region OnEnable & OnDisable

    private void OnEnable() => GameEvents.OnGetObjectsInPool += GetPooledObject;

    private void OnDisable() => GameEvents.OnGetObjectsInPool -= GetPooledObject;

    #endregion

    private void Awake() => PopulatePool();

    private void PopulatePool()
    {
        for (int j = 0; j < _pools.Length; j++)
        {
            _pools[j].Pool = new List<GameObject>();
            for (int i = 0; i < _pools[j].PoolSize; i++)
            {
                GameObject obj = ChooseObject(j);
                obj.SetActive(false);
                _pools[j].Pool.Add(obj);
            }
        }
    }

    private GameObject GetPooledObject(ObjectTypes objectType)
    {
        foreach (var poolIndex in _pools[(int)objectType].Pool.Where(poolIndex => poolIndex.activeInHierarchy == false))
        {
            poolIndex.SetActive(true);
            return poolIndex;

        }
        return null;
    }


    private GameObject ChooseObject(int objectTypes)
    {
        var objectType = _pools[objectTypes].ObjectPrefab;
        return objectTypes switch
        {
            (int)ObjectTypes.BarrackUi => Instantiate(objectType, _uiTransform),
            (int)ObjectTypes.PowerPlantUi => Instantiate(objectType, _uiTransform),
            (int)ObjectTypes.Barrack => Instantiate(objectType, _objectTransform),
            (int)ObjectTypes.Soldier => Instantiate(objectType, _objectTransform),
            (int)ObjectTypes.PowerPlant => Instantiate(objectType, _objectTransform),
            _ => null
        };
    }
}
