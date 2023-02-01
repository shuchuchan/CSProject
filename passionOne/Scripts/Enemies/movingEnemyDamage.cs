using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingEnemyDamage : EnemyDamage
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

    }

}
