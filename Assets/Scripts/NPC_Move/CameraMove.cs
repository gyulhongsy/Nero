using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 10.0f;
    private float tempValue;
    Camera Camera;

    void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * speed;

        // scroll < 0 : scroll down�ϸ� ����
        if (Camera.orthographicSize <= 2.67f && scroll > 0)
        {
            tempValue = Camera.orthographicSize;
            Camera.orthographicSize = tempValue; // maximize zoom in

            // �ִ�� Zoom in ���� �� Ư�� ���� �������� ��

            // �ִ� �� �� ������ ��� �� ���� ���߷��� �ѹ� �� �ƿ� �Ǵ� ������ ����
        }

        // scroll > 0 : scroll up�ϸ� �ܾƿ�
        else if (Camera.orthographicSize >= 7.03f && scroll < 0)
        {
            tempValue = Camera.orthographicSize;
            Camera.orthographicSize = tempValue; // maximize zoom out
        }
        else
            Camera.orthographicSize -= scroll * 0.5f;
    }
}
