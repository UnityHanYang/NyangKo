using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float dragSpeed = 15f;
    public float maxX = 0.0f;
    public float minX = -20.0f;

    private Vector3 clickPoint;
    private Vector3 targetPosition;
    private bool isDragging = false;

    void Update()
    {
        if (AllyTowerDestroy.instance.islive)
        {
            if (Input.GetMouseButtonDown(0) && !MoneyManager.Instance.isPauseP)
            {
                isDragging = true;
                clickPoint = Input.mousePosition;
                targetPosition = transform.position;
            }

            if (Input.GetMouseButtonUp(0) && !MoneyManager.Instance.isPauseP)
            {
                isDragging = false;
            }

            if (isDragging && !MoneyManager.Instance.isPauseP)
            {
                Vector3 position = Camera.main.ScreenToViewportPoint((Vector3)Input.mousePosition - clickPoint);
                position.z = 0f;
                position.y = 0f;

                Vector3 move = position * dragSpeed;
                move.x = -move.x;

                Vector3 newPosition = targetPosition + move;
                newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * dragSpeed);
            }
        }
    }

}
