using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class Hintergrund : MonoBehaviour
{
 public Camera Camera;
 public SpriteRenderer SpriteRenderer;

 private void Start()
 { 
  var worldSpaceHeight = Camera.orthographicSize * 2;
  var worldSpaceWidth = worldSpaceHeight * Camera.aspect;

  SpriteRenderer.size = new Vector2(worldSpaceWidth, worldSpaceHeight);
  }
}
