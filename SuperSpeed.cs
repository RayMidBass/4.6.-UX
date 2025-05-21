using UnityEngine;

public class SuperSpeed : MonoBehaviour
{
    public float boostMultiplier = 2f;
    public float boostDuration = 3f;
    private bool isBoosting = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isBoosting)
        {
            StartCoroutine(SpeedBoost(other));
        }
    }

    System.Collections.IEnumerator SpeedBoost(Collider player)
    {
        isBoosting = true;

        // Escalado visual (opcional)
        player.transform.localScale *= 1.5f;

        // Aumentar velocidad
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            pm.speed *= boostMultiplier;
        }

        yield return new WaitForSeconds(boostDuration);

        // Restaurar velocidad y escala
        player.transform.localScale /= 1.5f;
        if (pm != null)
        {
            pm.speed /= boostMultiplier;
        }

        isBoosting = false;
    }
}
