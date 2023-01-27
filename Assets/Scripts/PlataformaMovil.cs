using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{

    [SerializeField] private float velocidadDePlataforma = 0.5f;

    private float waitTime;


    [SerializeField] private Transform[] puntosDeMovimiento;

    [SerializeField] private float startWaitTime = 2;

    private int i = 0;

    private void Start()
    {
        waitTime = startWaitTime;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosDeMovimiento[i].transform.position, velocidadDePlataforma * Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosDeMovimiento[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (puntosDeMovimiento[i] != puntosDeMovimiento[puntosDeMovimiento.Length - 1])
                {
                    i++;
                }

                else
                {
                    i = 0;
                }

                waitTime = startWaitTime;
            }

            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
