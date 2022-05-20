using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;

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

        disappearTimer = 1f;
    }

    private void Update()
    {
        float moveYSpeed = 10f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

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
