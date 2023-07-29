using System.Collections;
using UnityEngine;

public class EnemyRandomMove : MonoBehaviour
{
    public float moveSpeed = 3f; // �G�̈ړ����x
    public float changeDirectionInterval = 2f; // ������ς���Ԋu�i�b�j

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
            // �����_���ȕ����ɕύX
            randomDirection = Random.insideUnitCircle.normalized;
            isMoving = true;

            // �w�肵���Ԋu�ŕ�����ς���
            yield return new WaitForSeconds(changeDirectionInterval);
        }
    }

    private void MoveRandomDirection()
    {
        // �ړ������Ɍ����Ď��_����]
        RotateTowardsMovementDirection();

        // �ړ�����
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
    }

    private void RotateTowardsMovementDirection()
    {
        if (randomDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(randomDirection.y, randomDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f); // �I�u�W�F�N�g�̏�������p�x0�Ȃ̂�-90�x��␳
        }
    }
}
