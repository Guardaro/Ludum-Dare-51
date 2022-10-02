using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMousePosition : MonoBehaviour
{
    float boxWidth;
    float boxHeight;

    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        Vector3 BottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, -mainCamera.transform.position.z));
        Vector3 TopRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -mainCamera.transform.position.z));
        boxWidth = TopRight.x - BottomLeft.x;
        boxHeight = TopRight.y - BottomLeft.y;
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        float worldY = mousePosition.y * boxHeight / Screen.height - boxHeight / 2f;
        float worldX = mousePosition.x * boxWidth / Screen.width - boxWidth / 2f;
        transform.position = new Vector3(worldX, worldY, transform.position.z);
    }
}
