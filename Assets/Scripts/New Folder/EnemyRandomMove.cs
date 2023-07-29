using System.Collections;
using UnityEngine;

public class EnemyRandomMove : MonoBehaviour
{
    public float moveSpeed = 3f; // 敵の移動速度
    public float changeDirectionInterval = 2f; // 方向を変える間隔（秒）

    private bool isMoving = false;
    private Vector2 randomDirection;

    private void Start()
    {
        StartCoroutine(RandomlyChangeDirection());
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveRandomDirection();
        }
    }

    private IEnumerator RandomlyChangeDirection()
    {
        while (true)
        {
            // ランダムな方向に変更
            randomDirection = Random.insideUnitCircle.normalized;
            isMoving = true;

            // 指定した間隔で方向を変える
            yield return new WaitForSeconds(changeDirectionInterval);
        }
    }

    private void MoveRandomDirection()
    {
        // 移動方向に向けて視点を回転
        RotateTowardsMovementDirection();

        // 移動する
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
    }

    private void RotateTowardsMovementDirection()
    {
        if (randomDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(randomDirection.y, randomDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f); // オブジェクトの上方向が角度0なので-90度を補正
        }
    }
}
