using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    #region Serialize

    [SerializeField] private ObjectTypes _objectType;

    #endregion

    
    public void SpawnObject() => GameEvents.GetObjectsInPoolMethod(_objectType);
}
