using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAtackWasp : MonoBehaviour
{
    public static PlayerAtackWasp instance; 
    public int health = 100;

    MeshRenderer meshh;
    public Color emissionColor = Color.red;
    public float effectDur = 1.0f;
    private Material matt;
    private Color ogColor;

    private void Awake()
    {
        if (instance == null)
        {
            meshh = GetComponent<MeshRenderer>();
            matt = meshh.material;
            ogColor = matt.GetColor("_EmmisionColor");

            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("¡Has sido picado! Salud restante: " + health);
        StartCoroutine(OnEmission());

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("El jugador ha muerto.");
        SceneManager.LoadScene(3);


    }

    private IEnumerator OnEmission() 
    {
        matt.SetColor("_EmissionColor", emissionColor);
        DynamicGI.SetEmissive(meshh, emissionColor);

        yield return new WaitForSeconds(effectDur);

        matt.SetColor("_EmissionColor", ogColor);
        DynamicGI.SetEmissive(meshh, ogColor);

    }
}
