using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VaultGate : MonoBehaviour
{
    public Sprite brokenGateSprite;
    public SpriteRenderer gateRenderer;
    public SpriteRenderer[] peopleRenderers;
    public Sprite deathSprite;
    private float health = 5;
    public GameObject victoryMessage;
    private TextMeshProUGUI victoryText;
    public Text mainText;
    public Image redOverlay;

    private bool isBroken = false;

    void Start()
    {

        if (victoryMessage != null)
        {
            victoryText = victoryMessage.GetComponent<TextMeshProUGUI>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isBroken)
        {
            BreakGate();
        }
    }
    public void TakeDamage(float amount)
    {
        if (GetComponent<SpriteRenderer>().sprite != brokenGateSprite)
        {
            health -= amount;
            GetComponent<SpriteRenderer>().color = Color.red;
            if (health < 0)
            {
                GetComponent<SpriteRenderer>().sprite = deathSprite;
                Invoke(nameof(BreakGate), 0.5f);
            }
            Invoke(nameof(DefaultColor), 0.3f);
        }
    }

    private void BreakGate()
    {
        isBroken = true;
        Destroy(gameObject);
        if (health < 1)
        {
            mainText.gameObject.SetActive(true);
            mainText.text = "Victory";
            redOverlay.gameObject.SetActive(true);
        }
    }
    private void DefaultColor()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}