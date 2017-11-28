using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class healthBar : MonoBehaviour {
	
	public int m_StartingHealth = 100;               // The amount of health each tank starts with.
	public Slider m_Slider;                             // The slider to represent how much health the tank currently has.
	public Image m_FillImage;                           // The image component of the slider.
	public Color m_FullHealthColor = Color.green;       // The color the health bar will be when on full health.
	public Color m_ZeroHealthColor = Color.red;         // The color the health bar will be when on no health.


	private int m_CurrentHealth;                      // How much health the tank currently has.
	private bool m_Dead;                                // Has the tank been reduced beyond zero health yet?

	private void OnEnable()
	{
		// When the tank is enabled, reset the tank's health and whether or not it's dead.
		m_CurrentHealth = m_StartingHealth;
		m_Dead = false;
		
		// Update the health slider's value and color.
		SetHealthUI();
	}

	public void decrease (int damage)
	{
		// Reduce current health by the amount of damage done.
		m_CurrentHealth -= damage;

		// Change the UI elements appropriately.
		SetHealthUI ();
			
		// If the current health is at or below zero and it has not yet been registered, call OnDeath.
		if (m_CurrentHealth <= 0 && !m_Dead)
		{
			OnDeath ();
		}
	}

	private void SetHealthUI ()
	{
		// Set the slider's value appropriately.
		m_Slider.value = m_CurrentHealth;
		
		// Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
		m_FillImage.color = Color.Lerp (m_FullHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
	}

	private void OnDeath ()
	{
		// Set the flag so that this function is only called once.
		m_Dead = true;

		if (gameObject.tag == "Enemy") {
			GameObject.Find("GameManager").GetComponent<GameManager>().kills++;
			if(SceneManager.GetActiveScene().name == "Level2") {
				GameObject.Find("Level2Manager").GetComponent<Level2Manager>().EnemyDied();
			}
		}
		Destroy(gameObject);
			
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);

	}
}