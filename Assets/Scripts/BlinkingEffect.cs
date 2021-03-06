﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BlinkingEffect : MonoBehaviour {
    public EnemyCharacter self;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private float recoverRate = 12f;

    void Start()
    {
        self.TakeDamageEvent += delegate {
            blinkOnce();
        };
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            blinkOnce();
        if (Input.GetKeyDown(KeyCode.U))
            blinkMultiple();
    }

    void blinkOnce()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.1f);
        StartCoroutine(recoverToNormal());
    }

    void blinkMultiple()
    {
        StartCoroutine(blinkMultipleEffects());
        StartCoroutine(recoverToNormal());
    }

    IEnumerator blinkMultipleEffects()
    {
        for (int n = 0; n < 5; n++)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

    IEnumerator recoverToNormal()
    {
        while (originalColor.a - spriteRenderer.color.a > 0.01)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, originalColor, Time.deltaTime * recoverRate);
            yield return null;
        }
        spriteRenderer.color = originalColor;
        yield return null;
    }

}
