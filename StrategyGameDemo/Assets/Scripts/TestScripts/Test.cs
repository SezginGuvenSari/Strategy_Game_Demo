using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{

    RaycastHit hit;

    private Vector3 _startPos;

    private float minX = 0;

    private bool isLocate = true;
    
    private void Start()
    {
        _startPos = transform.position;

     
    }


    private void Update()
    {
        //  RayTest();


        if (Input.GetMouseButtonDown(0))
        {
            isLocate = false;
        }
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && hit.transform.tag == "Tile" && isLocate)
            {
                print("2");

                var targetPos = new Vector3((hit.transform.position.x + _startPos.x), (hit.transform.position.y + _startPos.y), 0);
                targetPos.y = Mathf.Clamp(targetPos.y, _startPos.y, 5.44f - _startPos.y);
                targetPos.x = Mathf.Clamp(targetPos.x, _startPos.x, 5.44f - _startPos.x);
                transform.position = Vector3.Lerp(transform.position, targetPos, 1f);

            }
        
    }

    private void RayTest()
    {
        //Will be delete then after test.
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = new Vector2(0f, 0f);
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                print(hit.transform.gameObject.name);
                print(hit.transform.position);
            }
        }
    }


}
