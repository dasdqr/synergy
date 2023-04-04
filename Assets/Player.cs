using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 screenSpace;
    private Vector3 offset;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnMouseDown()  // 마우스 클릭
    {       
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);     
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
    }
    
    private void OnMouseDrag() // 드래그 앤 드롭 실행 중
    {
        var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
        var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
        transform.position = curPosition;      
    }
    
}