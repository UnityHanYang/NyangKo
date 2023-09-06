using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraM : MonoBehaviour
{
    private float dragSpeed = 19f;

    private Vector3 clickPoint;
    private Vector3 targetPosition;
    private bool isDragging = false;
    public GameObject go;
    private Vector3 vec;
    private int num;
    private float maxX;
    private float minX = 0.0f;

    private void Start()
    {
        num = CountryCount.instance.countryClearCountP;
        switch (num)
        {
            case 0:
                maxX = 0.0f;
                break;
            case 1:
                maxX = 10.65f;
                transform.position = new Vector3(maxX, 0f, -8.4f);
                vec = transform.position;
                vec.y = go.transform.position.y;
                go.transform.position = vec;
                break;
            default:
                maxX = num * 8.34f;
                transform.position = new Vector3(maxX, 0f, -8.4f);
                vec = transform.position;
                vec.y = go.transform.position.y;
                go.transform.position = vec;
                break;
        }
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            clickPoint = Input.mousePosition;
            targetPosition = transform.position;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 position = Camera.main.ScreenToViewportPoint((Vector3)Input.mousePosition - clickPoint);
            position.z = 0f;
            position.y = 0f;

            Vector3 move = position * dragSpeed;
            move.x = -move.x;

            Vector3 newPosition = targetPosition + move;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * dragSpeed);

            vec = newPosition;
            vec.y = go.transform.position.y;
            go.transform.position = Vector3.Lerp(go.transform.position, vec, Time.deltaTime * dragSpeed);
        }
    }
}
