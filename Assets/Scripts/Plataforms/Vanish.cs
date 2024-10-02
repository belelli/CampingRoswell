using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanish : MonoBehaviour
{
    public float delayBeforeVanish = 2f;
    public float vanishDuration = 3f;
    public float invisibleDuration = 2f;

    private bool isVanishing = false;
    private Renderer platformRenderer;
    private Collider platformCollider;
    private Material platformMaterial;

    void Start()
    {
        platformRenderer = GetComponent<Renderer>();
        platformCollider = GetComponent<Collider>();

        // Crear una instancia del material para modificarlo sin afectar otros objetos
        platformMaterial = new Material(platformRenderer.material);
        platformRenderer.material = platformMaterial;

        // Asegurarse de que el shader soporte transparencia
        platformMaterial.SetFloat("_Mode", 2);
        platformMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        platformMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        platformMaterial.SetInt("_ZWrite", 0);
        platformMaterial.DisableKeyword("_ALPHATEST_ON");
        platformMaterial.EnableKeyword("_ALPHABLEND_ON");
        platformMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        platformMaterial.renderQueue = 3000;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isVanishing)
        {
            StartCoroutine(VanishAndReappear());
        }
    }

    IEnumerator VanishAndReappear()
    {
        isVanishing = true;

       
        yield return new WaitForSeconds(delayBeforeVanish);

        // Desvanecer
        float elapsedTime = 0f;
        Color originalColor = platformMaterial.color;
        while (elapsedTime < vanishDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / vanishDuration);
            platformMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            if (alpha < 0.1f)
            {
                platformCollider.enabled = false;
            }

            yield return null;
        }

       
        yield return new WaitForSeconds(invisibleDuration);

        // Reaparecer
        elapsedTime = 0f;
        while (elapsedTime < vanishDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / vanishDuration);
            platformMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            if (alpha > 0.9f)
            {
                platformCollider.enabled = true;
            }

            yield return null;
        }

        isVanishing = false;
    }
}

