using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ��� (�÷��̾�)
    public float smoothSpeed = 0.005f; // ī�޶� �̵� ������ ���� 0.00xf => x���� �÷��̾� �ӵ�
    Vector2 offset; // ī�޶�� ��� ������ ������

    public float leftLimit; // ī�޶��� ���� �Ѱ�
    public float rightLimit; // ī�޶��� ������ �Ѱ�
    float topLimit; // ī�޶��� ���� �Ѱ�
    float bottomLimit; // ī�޶��� �Ʒ��� �Ѱ�

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(
                Mathf.Clamp(smoothedPosition.x, leftLimit, rightLimit),
                Mathf.Clamp(smoothedPosition.y, bottomLimit, topLimit),
                smoothedPosition.z
            );
        }
    }
}
