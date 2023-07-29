using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRandom2 : MonoBehaviour
{
    public float moveSpeed = 3f; // NPCの移動速度
    public float changeDirectionInterval = 3f; // 方向を変える間隔

    private float timeSinceLastDirectionChange = 0f; // 前回の方向変更からの経過時間
    private Vector2 currentDirection; // 現在の移動方向

    private void Start()
    {
        // 初回の方向をランダムに決定
        ChangeDirection();
    }

    private void Update()
    {
        timeSinceLastDirectionChange += Time.deltaTime;

        // 方向を変える間隔を超えたら新しい方向をランダムに決定
        if (timeSinceLastDirectionChange >= changeDirectionInterval)
        {
            ChangeDirection();
        }

        // 移動
        Move();
    }

    public void ChangeDirection()
    {
        // ランダムな方向を決定（-1.0 から 1.0 の間のランダムな x と y の値を持つベクトル）
        currentDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // 方向変更のタイマーリセット
        timeSinceLastDirectionChange = 0f;

        // NPCの向きを移動方向に合わせる
        transform.up = currentDirection;
    }

    private void Move()
    {
        // 移動
        transform.position += (Vector3)(currentDirection * moveSpeed * Time.deltaTime);
    }
}
