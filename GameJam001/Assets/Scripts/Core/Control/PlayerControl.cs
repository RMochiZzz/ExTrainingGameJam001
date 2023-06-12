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
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        playerMove.MoveStance(moveX, moveY);

    }
}
