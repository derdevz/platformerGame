using System.Collections;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;

public class FlagAnimation : MonoBehaviour
{
    private Animator _anim;
    private bool _flagFirstActive = false;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_flagFirstActive)
            {
                return;    
            }

            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.SetCheckpoint(transform.position);
                
                StartCoroutine(FlagSystem());
            }
        }
    }
    
    private IEnumerator FlagSystem()
    {
        _anim.SetTrigger("FlagOut");

        yield return new WaitForSeconds(2.10f);

        _anim.SetBool("FlagIdle", true);
    }
}
