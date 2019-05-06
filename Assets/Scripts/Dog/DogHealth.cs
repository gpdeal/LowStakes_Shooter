using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogHealth : MonoBehaviour
{

    public float maxHealth = 100;
    public float currentHealth;

    private SpriteRenderer muddySprite;
    private DogMovement movement;
    private Color mudColor;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        muddySprite = transform.Find("MuddySprite").GetComponent<SpriteRenderer>();
        movement = GetComponent<DogMovement>();
        mudColor = muddySprite.color;
    }

    public void Clean(float cleanAmount)
    {
        if (currentHealth > 0)
        {
            float normalizedAlphaChangeAmount = (cleanAmount / maxHealth);

            mudColor = muddySprite.color;
            currentHealth -= cleanAmount;
            mudColor.a -= normalizedAlphaChangeAmount;
            muddySprite.color = mudColor;
        }
    }
}
