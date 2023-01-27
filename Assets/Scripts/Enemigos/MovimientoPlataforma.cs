using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{

    [SerializeField] private float velocidad;

    [SerializeField] private Transform controladoSuelo;

    [SerializeField] private float distancia;

    [SerializeField] private bool moviendoDerecha;

    private Rigidbody2D myrb;

    private void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladoSuelo.position, Vector2.down, distancia);

        myrb.velocity = new Vector2(velocidad, myrb.velocity.y);

        if (informacionSuelo == false)
        {
            Girar();
        }
    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladoSuelo.transform.position, controladoSuelo.transform.position + Vector3.down * distancia);
    }

}
