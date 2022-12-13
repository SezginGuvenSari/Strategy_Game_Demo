using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{

    #region References

    private RaycastHit2D _hit;

    #endregion

    #region Serialize


    #endregion

    private void Update() => Interact();

    private void Interact()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _hit = Physics2D.Raycast(ray, Vector2.zero);

            if (_hit.collider == null) return;

            IInteractable interact = _hit.collider.GetComponent<IInteractable>();
            interact?.Interact();
        }

        if (Input.GetMouseButtonDown(1))
        {
            var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _hit = Physics2D.Raycast(ray, Vector2.zero);

            if (_hit.collider == null) return;

            var barrack = _hit.collider.GetComponent<BarrackData>();
            if (barrack != null && barrack.IsBuild)
            {
                GameEvents.GetSoldierMethod();
            }
        }
    }
}
