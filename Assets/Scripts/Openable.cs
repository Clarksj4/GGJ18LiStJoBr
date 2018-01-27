﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour
{
    public XWindow xWindowPrefab;
    public RectTransform canvas;

    private XWindow openInstance;

    private void OnMouseUp()
    {
        if (openInstance == null)
        {
            openInstance = Instantiate(xWindowPrefab, transform.parent) as XWindow;
            openInstance.Open(WorldPositionToCanvasPosition(), Vector2.zero, Vector2.one * 100);
        }

        else
        {
            openInstance.Close(WorldPositionToCanvasPosition());
        }
    }

    private Vector2 WorldPositionToCanvasPosition()
    {
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 canvasPosition = new Vector2(
        ((ViewportPosition.x * canvas.sizeDelta.x) - (canvas.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * canvas.sizeDelta.y) - (canvas.sizeDelta.y * 0.5f)));

        return canvasPosition;
    }
}