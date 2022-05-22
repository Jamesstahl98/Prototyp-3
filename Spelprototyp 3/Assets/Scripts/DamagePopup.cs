using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;
    private const float disappearTimerMax = 1f;

    public static DamagePopup Create(Vector3 position, float damageAmount, bool isWeak, bool isStrong)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isWeak, isStrong);

        return damagePopup;
    }

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(float damageAmount, bool isWeak, bool isStrong)
    {
        textMesh.SetText(damageAmount.ToString());
        if (isWeak)
        {
            textMesh.fontSize = 24;
            textColor = Color.yellow;
        }
        else if (isStrong)
        {
            textMesh.fontSize = 36;
            textColor = new Color(1,0,0,1);
        }
        else
        {
            textMesh.fontSize = 30;
            textColor = textMesh.color;
        }
        textMesh.color = textColor;
        disappearTimer = disappearTimerMax;

        moveVector = new Vector3(.7f, .5f) * 60f;
    }

    private void Update()
    {
        float moveYSpeed = 10f;
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 8f * Time.deltaTime;

        if (disappearTimer > disappearTimerMax * .5f)
        {
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 2f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
