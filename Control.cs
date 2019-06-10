using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float speed;
    public float error;
    private bool moveit = false;
    private Vector3 targetpos;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            moveit = true;
        }
        if (moveit)
        {
            float dis = targetpos.x - transform.position.x;
            if (Mathf.Abs(dis) <= error)
            {
                moveit = false;
            }
            Debug.Log(dis);
            if (dis > 0)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else if (dis < 0)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
             }
        }
    }
}
