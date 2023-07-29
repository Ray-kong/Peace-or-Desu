using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRandom : MonoBehaviour
{
    public float moveSpeed = 3f; // NPCの移動速度
    public float changeDirectionInterval = 3f; // 方向を変える間隔

    private float timeSinceLastDirectionChange = 0f; // 前回の方向変更からの経過時間
    private Vector2 currentDirection; // 現在の移動方向

    private bool isChangingDirection = false; // 方向転換中かどうかのフラグ

    private void Start()
    {
        // 初回の方向をランダムに決定
        ChangeDirection();
    }

    private void Update()
    {
        timeSinceLastDirectionChange += Time.deltaTime;

        // 方向を変える間隔を超えたら新しい方向に向く
        if (timeSinceLastDirectionChange >= changeDirectionInterval)
        {
            ChangeDirection();
        }

        // 方向転換中は動かない
        if (isChangingDirection)
        {
            return;
        }

        // 移動
        Move();
    }

    private void ChangeDirection()
    {
        // ランダムな方向を決定（-1.0 から 1.0 の間のランダムな x と y の値を持つベクトル）
        Vector2 newDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // 方向変更のタイマーリセット
        timeSinceLastDirectionChange = 0f;

        // 方向転換コルーチンを実行
        StartCoroutine(TurnToNewDirection(newDirection));
    }

    private IEnumerator TurnToNewDirection(Vector2 newDirection)
    {
        // 方向転換中のフラグを立てる
        isChangingDirection = true;

        // 新しい方向に向く
        float targetAngle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg - 90f;
        float currentAngle = transform.eulerAngles.z;
        float elapsed = 0f;
        float duration = 0.5f; // 方向転換にかける時間（秒）

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float angle = Mathf.LerpAngle(currentAngle, targetAngle, elapsed / duration);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            yield return null;
        }

        // 方向転換終了後、移動方向を更新してフラグをリセット
        currentDirection = newDirection;
        isChangingDirection = false;
    }

    private void Move()
    {
        // 移動
        transform.position += (Vector3)(currentDirection * moveSpeed * Time.deltaTime);
    }
}
