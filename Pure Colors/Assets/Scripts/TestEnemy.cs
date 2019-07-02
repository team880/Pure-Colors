using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : EnemyBase
{
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        Move(Direction());
    }

    private Vector2 Direction()
    {
        Vector2 vec = new Vector2();
        vec.x = -0.5f;
        vec.y = Mathf.Sin(Time.time * 4);
        vec = Vector3.Normalize(vec);
        return vec;
    }

}
