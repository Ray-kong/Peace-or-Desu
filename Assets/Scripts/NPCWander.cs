using System.Collections;
using UnityEngine;

public class NPCWander : MonoBehaviour
{
    public Transform[] wanderPoints; // NPC���p�j����ꏊ�̔z��

    public float moveSpeed = 3f; // NPC�̈ړ����x
    public float waitTime = 2f; // �p�j�n�_�ɓ���������̑ҋ@����

    private int currentPointIndex = 0; // ���݂̖ڕW�n�_�̃C���f�b�N�X
    private Transform currentPoint; // ���݂̖ڕW�n�_

    private bool isWaiting = false; // �ҋ@�����ǂ����̃t���O

    private void Start()
    {
        // �ŏ��̖ڕW�n�_��ݒ�
        if (wanderPoints.Length > 0)
        {
            currentPoint = wanderPoints[0];
        }
    }

    private void Update()
    {
        if (!isWaiting)
        {
            // �ڕW�n�_�Ɍ������Ĉړ�����
            MoveTowardsTarget();

            // �ڕW�n�_�ɋ߂Â�����ҋ@
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.1f)
            {
                StartCoroutine(WaitAtPoint());
            }
        }
    }

    private void MoveTowardsTarget()
    {
        // �ڕW�n�_�̕������v�Z
        Vector2 moveDirection = currentPoint.position - transform.position;

        // �L�����N�^�[�̈ړ������ɍ��킹�Ĉړ�����
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);
    }

    private IEnumerator WaitAtPoint()
    {
        // �ҋ@�t���O�𗧂āA�ҋ@���Ԃ����҂�
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;

        // ���̖ڕW�n�_�֐i��
        UpdateNextPoint();
    }

    private void UpdateNextPoint()
    {
        // ���̖ڕW�n�_�̃C���f�b�N�X���X�V
        currentPointIndex = (currentPointIndex + 1) % wanderPoints.Length;

        // ���̖ڕW�n�_��ݒ�
        currentPoint = wanderPoints[currentPointIndex];
    }
}
