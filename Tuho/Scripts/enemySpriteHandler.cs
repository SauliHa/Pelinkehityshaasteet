using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemySpriteHandler : MonoBehaviour
{
    AIPath aiPath;
    enemyScript es;

    private void Start()
    {
        aiPath = GetComponentInParent<AIPath>();
        es = GetComponentInParent<enemyScript>();
    }

    private void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(3.5f, 3.5f, 1f);
        }else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-3.5f, 3.5f, 1f);
        }
    }
}
