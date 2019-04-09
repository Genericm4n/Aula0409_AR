using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    public float distance = 3f;
    public float vel = 0.015f;
    public float rvel = 2f;

    private Vector3 local;

    private void Start()
    {
        // No começo do jogo, o personagem ficará parado
        local = transform.position;
    }

    private void Update()
    {
        updatePosition();

        Move();

        Rotate();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * vel * Time.deltaTime);
    }

    private void Rotate()
    {
        var rotateLocal = Quaternion.LookRotation(local);
        var rotatione = Quaternion.Slerp(transform.rotation, rotateLocal, rvel * Time.deltaTime);

        rotatione.eulerAngles = new Vector3(0, rotatione.eulerAngles.y, 0);

        transform.rotation = rotatione;
    }

    private void updatePosition()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance))
            {
                //Ray tocou em algum ponto

                local = hit.point;
                local.y = transform.position.y;
            }
        }
    }
}