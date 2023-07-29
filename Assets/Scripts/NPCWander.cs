using System.Collections;
using UnityEngine;

public class NPCWander : MonoBehaviour
{
    public Transform[] wanderPoints; // NPCが徘徊する場所の配列

    public float moveSpeed = 3f; // NPCの移動速度
    public float waitTime = 2f; // 徘徊地点に到着した後の待機時間

    private int currentPointIndex = 0; // 現在の目標地点のインデックス
    private Transform currentPoint; // 現在の目標地点

    private bool isWaiting = false; // 待機中かどうかのフラグ

    private void Start()
    {
        // 最初の目標地点を設定
        if (wanderPoints.Length > 0)
        {
            currentPoint = wanderPoints[0];
        }
    }

    private void Update()
    {
        if (!isWaiting)
        {
            // 目標地点に向かって移動する
            MoveTowardsTarget();

            // 目標地点に近づいたら待機
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.1f)
            {
                StartCoroutine(WaitAtPoint());
            }
        }
    }

    private void MoveTowardsTarget()
    {
        // 目標地点の方向を計算
        Vector2 moveDirection = currentPoint.position - transform.position;

        // キャラクターの移動方向に合わせて移動する
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);
    }

    private IEnumerator WaitAtPoint()
    {
        // 待機フラグを立て、待機時間だけ待つ
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;

        // 次の目標地点へ進む
        UpdateNextPoint();
    }

    private void UpdateNextPoint()
    {
        // 次の目標地点のインデックスを更新
        currentPointIndex = (currentPointIndex + 1) % wanderPoints.Length;

        // 次の目標地点を設定
        currentPoint = wanderPoints[currentPointIndex];
    }
}
