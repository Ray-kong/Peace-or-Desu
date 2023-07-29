using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRandom : MonoBehaviour
{
    public float moveSpeed = 3f; // NPC�̈ړ����x
    public float changeDirectionInterval = 3f; // ������ς���Ԋu

    private float timeSinceLastDirectionChange = 0f; // �O��̕����ύX����̌o�ߎ���
    private Vector2 currentDirection; // ���݂̈ړ�����

    private bool isChangingDirection = false; // �����]�������ǂ����̃t���O

    private void Start()
    {
        // ����̕����������_���Ɍ���
        ChangeDirection();
    }

    private void Update()
    {
        timeSinceLastDirectionChange += Time.deltaTime;

        // ������ς���Ԋu�𒴂�����V���������Ɍ���
        if (timeSinceLastDirectionChange >= changeDirectionInterval)
        {
            ChangeDirection();
        }

        // �����]�����͓����Ȃ�
        if (isChangingDirection)
        {
            return;
        }

        // �ړ�
        Move();
    }

    private void ChangeDirection()
    {
        // �����_���ȕ���������i-1.0 ���� 1.0 �̊Ԃ̃����_���� x �� y �̒l�����x�N�g���j
        Vector2 newDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // �����ύX�̃^�C�}�[���Z�b�g
        timeSinceLastDirectionChange = 0f;

        // �����]���R���[�`�������s
        StartCoroutine(TurnToNewDirection(newDirection));
    }

    private IEnumerator TurnToNewDirection(Vector2 newDirection)
    {
        // �����]�����̃t���O�𗧂Ă�
        isChangingDirection = true;

        // �V���������Ɍ���
        float targetAngle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg - 90f;
        float currentAngle = transform.eulerAngles.z;
        float elapsed = 0f;
        float duration = 0.5f; // �����]���ɂ����鎞�ԁi�b�j

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float angle = Mathf.LerpAngle(currentAngle, targetAngle, elapsed / duration);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            yield return null;
        }

        // �����]���I����A�ړ��������X�V���ăt���O�����Z�b�g
        currentDirection = newDirection;
        isChangingDirection = false;
    }

    private void Move()
    {
        // �ړ�
        transform.position += (Vector3)(currentDirection * moveSpeed * Time.deltaTime);
    }
}
