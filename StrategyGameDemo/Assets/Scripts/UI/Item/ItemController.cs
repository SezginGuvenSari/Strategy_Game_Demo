using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    #region Serialize

    [SerializeField] private ObjectTypes _objectType;

    #endregion

    #region References

    private ItemManager _itemManager;

    #endregion

    private void Awake() => _itemManager = GetComponentInParent<ItemManager>();
    public void SpawnObject()
    {
        if (_itemManager.IsSpawned) return;

        _itemManager.IsSpawned = true;
        GameEvents.GetObjectsInPoolMethod(_objectType);
    }
}
