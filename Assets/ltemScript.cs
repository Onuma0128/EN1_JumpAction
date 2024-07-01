using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ltemScript : MonoBehaviour
{
    private Animator animator;
    public GameObject clearText;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Get");
        audioSource.Play();
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
        clearText.SetActive(true);
    }
}
