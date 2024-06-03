using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenImageOnKeyPress : MonoBehaviour
{
    public KeyCode keyToToggle = KeyCode.E;
    public float zoomSpeed = 2f;

    private RawImage rawImage;
    private bool isImageVisible = false;

    private bool isDragging = false;
    private Vector2 dragStartPosition;
    private Vector2 originalImagePosition;

    public Texture2D imageToShow; // ѕрисвойте вашу текстуру из редактора Unity

    void Start()
    {
        rawImage = GetComponent<RawImage>();
        rawImage.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToToggle))
        {
            ToggleImageVisibility();
        }

        if (isImageVisible)
        {
            HandleMouseInput();
        }
    }

    void ToggleImageVisibility()
    {
        isImageVisible = !isImageVisible;
        rawImage.enabled = isImageVisible;

        if (isImageVisible)
        {
            rawImage.texture = imageToShow;
            originalImagePosition = rawImage.rectTransform.position;
        }
    }

    void HandleMouseInput()
    {
        // Zoom with the scroll wheel
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        rawImage.rectTransform.localScale = new Vector2(
            rawImage.rectTransform.localScale.x + scrollWheel * zoomSpeed,
            rawImage.rectTransform.localScale.y + scrollWheel * zoomSpeed
        );

        // Drag with the left mouse button
        if (Input.GetMouseButtonDown(1))
        {
            isDragging = true;
            dragStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector2 delta = (Vector2)Input.mousePosition - dragStartPosition;
            rawImage.rectTransform.position = originalImagePosition + delta;
        }
    }
}
