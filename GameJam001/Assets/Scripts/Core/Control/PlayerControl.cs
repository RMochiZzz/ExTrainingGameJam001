using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMoveSystem;

public class PlayerControl : MonoBehaviour
{
    private PlayerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GManager.instance.isGameClear) return;
        if (GManager.instance.isGameOver) return;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        playerMove.MoveStance(moveX, moveY);

    }
}
