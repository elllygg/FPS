using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Stats")]
    public float maxHealth = 100f;
    public float health;

    [Header("UI")]
    public Slider healthSlider;   //barra vita
    public GameObject deathUI;    //canva "Sei morto"

    void Start()
    {
        health = maxHealth;

        if (healthSlider != null)
            healthSlider.value = health / maxHealth;

        if (deathUI != null)
            deathUI.SetActive(false);  //UI della morte nascosta inizialmente
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (healthSlider != null)
        {
            healthSlider.value = Mathf.Clamp01(health / maxHealth);
        }

        Debug.Log("Sei stato attaccato! Vita Player: " + health);

        if (health <= 0)  //quando la salute è 0 o meno, il player muore
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Sei morto!");

        //mostra il canvas della morte
        if (deathUI != null)
            deathUI.SetActive(true);

        

        //ferma il gioco
        Time.timeScale = 0f;

        //mostra il cursore per interagire con il menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //suono gameover
        if (AudioManager.instance != null)
            AudioManager.instance.PlayGameOver();
    }
}