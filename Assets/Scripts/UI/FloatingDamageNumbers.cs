using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatingDamageNumbers : MonoBehaviour
{
    public GameObject damageTextPrefab;
    private Canvas canvas;
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
    public void ShowDamage(Vector3 worldPosition, float damageAmount)
    {
        // Convert world position to screen position
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

        // Instantiate under the UI canvas
        GameObject dmg = Instantiate(damageTextPrefab, canvas.transform);

        // Set position in screen space
        dmg.GetComponent<RectTransform>().position = screenPosition;

        // Set text
        dmg.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = damageAmount.ToString();

        StartCoroutine(FloatAndFade(dmg));
    }

    IEnumerator FloatAndFade(GameObject text)
    {
        TMP_Text textBox = text.GetComponent<TMP_Text>();
        float duration = 1f;
        Vector3 startPos = textBox.transform.position;
        Vector3 endPos = startPos + Vector3.up * 1f;

        Color startColor = textBox.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);

        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float progress = t / duration;

            textBox.transform.position = Vector3.Lerp(startPos, endPos, progress);
            textBox.color = Color.Lerp(startColor, endColor, progress);

            yield return null;
        }

        Destroy(text.gameObject);
    }
}
