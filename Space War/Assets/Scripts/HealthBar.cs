using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
   
{
    [SerializeField] private PlayerHealth PlayerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        totalhealthBar.fillAmount = PlayerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth.fillAmount = PlayerHealth.currentHealth / 10;
    }
}
