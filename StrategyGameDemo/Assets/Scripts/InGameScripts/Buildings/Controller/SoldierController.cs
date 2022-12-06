using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    #region References

    private SoldierData _soldierData;

    #endregion

    #region Serialize


    #endregion

    #region Properties



    #endregion

    private void Awake() => Initialize();

    void Start()
    {

    }

    private void Initialize() => _soldierData = GetComponent<SoldierData>();

    void Update()
    {

    }
}
