using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayer : MonoBehaviour
{
    [SerializeField] private float vida;

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

}
