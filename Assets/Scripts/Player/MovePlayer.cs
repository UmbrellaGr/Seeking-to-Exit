using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D myrb;


    [Header("Movmiento")]

    private float movimientoHorizontal = 0f;

    [SerializeField] private float velocidadDeMovimiento;

    [Range(0, 0.3f)] [SerializeField] private float suavizadoDeMovimiento;

    private Vector3 velocidad = Vector3.zero;

    private bool mirandoDerecha = true;


    [Header("Salto")]

    [SerializeField] private float fuerzaDeSalto;

    [SerializeField] private LayerMask queEsSuelo;

    [SerializeField] private Transform controladorSuelo;

    [SerializeField] private Vector3 dimensionesCaja;

    [SerializeField] private bool enSuelo;

    private bool salto = false;

    [Header("Rebote")]

    [SerializeField] private float velocidadRebote;

    [Header("Animacion")]

    private Animator animator;

    

    private void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();      
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        animator.SetFloat("VelocidadY", myrb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }

    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

        animator.SetBool("enSuelo", enSuelo);

        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

        salto = false;

    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, myrb.velocity.y);
        myrb.velocity = Vector3.SmoothDamp(myrb.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }

        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        if (enSuelo && saltar)
        {
            enSuelo = false;
            myrb.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }


    public void Rebote()
    {
        myrb.velocity = new Vector2(myrb.velocity.x, velocidadRebote);
    }


    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}
