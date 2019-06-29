using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : ProjectileBase
{

    private void FixedUpdate()
    {
        Fly(SetFlightDirection(), projectileSpeed);
    }
   public override Vector2 SetFlightDirection()
   {
       return transform.up;
   }
}
