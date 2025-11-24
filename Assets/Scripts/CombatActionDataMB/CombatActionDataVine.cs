using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActionDataVine : CombatActionDataMB
{
    public Vector3 mousePosition;

    public Rigidbody2D rb;

    public void Update()
    {

        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPoint2D = new Vector2(worldPoint.x, worldPoint.y);
        mousePosition = worldPoint2D;
    }

}
