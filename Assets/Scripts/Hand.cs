using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool isLeft;
    public SpriteRenderer spriter;

    SpriteRenderer player;

    Vector3 rightPos = new Vector3(0.35f, -0.15f, 0);
    Vector3 rightPosReverse = new Vector3(-0.15f, -0.15f, 0);
    Quaternion leftRot = Quaternion.Euler(0, 0, -35);
    Quaternion leftRotReverse = Quaternion.Euler(0, 0, -135);

    void Awake()
    {
        player = GetComponentsInParent<SpriteRenderer>()[1];
    }

    private void LateUpdate()
    {
        bool isRevese = player.flipX;
        if (isLeft)
        {
            transform.localRotation = isRevese ? leftRotReverse : leftRot;
            spriter.flipY = isRevese;
            spriter.sortingOrder = isRevese ? 4 : 6;
        }
        else
        {
            transform.localPosition = isRevese ? rightPosReverse : rightPos;
            spriter.flipX = isRevese;
            spriter.sortingOrder = isRevese ? 6 : 4;
        }
    }
}
