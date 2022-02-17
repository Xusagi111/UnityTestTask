using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Drag2dObjects : MonoBehaviour
{
    private bool _isDraged = false;
    private Plane _planeXY;
    private Rigidbody2D _rb2D;
    private HingeJoint2D _hindleJoint2D;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _rb2D.isKinematic = true;
        _isDraged = false;
    }

    void Update()
    {
        // �������� ��������������, ���� ������ �� �����-�� ������ � �����
        if (Input.GetMouseButtonDown(0) && _isDraged == false )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider != null && hit2D.collider.tag =="Player")
            {
                _planeXY = new Plane(Vector3.forward, hit2D.transform.position);
                _rb2D.position = hit2D.point;

                _hindleJoint2D = hit2D.transform.gameObject.AddComponent<HingeJoint2D>();
                _hindleJoint2D.connectedBody = this._rb2D;
                _hindleJoint2D.GetComponent<Rigidbody2D>().gravityScale = 0;
                _isDraged = true;
            }
        }

        // ���������� �������������� ��� ���������� ����
        if (Input.GetMouseButtonUp(0) && _isDraged)
        {
            Destroy(_hindleJoint2D);
            _isDraged = false;
        }

        // ����������� ��������������
        if (_isDraged)
        {
            if (_hindleJoint2D == null || _hindleJoint2D.gameObject == null)
            {
                _hindleJoint2D = null;
                _isDraged = false;
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (_planeXY.Raycast(ray, out float enterPoint))
            {
                _rb2D.position = ray.GetPoint(enterPoint);
            }
        }
    }
}
