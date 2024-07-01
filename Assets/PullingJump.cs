using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 50;
    private bool isCanJump;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (isCanJump && Input.GetMouseButtonUp(0))
        {
            Vector3 dist = clickPosition - Input.mousePosition;
            if(dist.sqrMagnitude == 0) { return; }
            rb.velocity = dist.normalized * jumpPower;
            audioSource.Play();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("衝突した");
    }
    private void OnCollisionStay(Collision collision)
    {
        //isCanJump = true;
        //衝突している点の情報が複数格納されている
        ContactPoint[] contacts = collision.contacts;
        //0番目の衝突情報から、衝突している点の法線を取得
        Vector3 otherNormal = contacts[0].normal;
        //上方向を示すベクトル、長さは1
        Vector3 upVetor = new Vector3(0, 1, 0);
        //
        float dotUN = Vector3.Dot(upVetor, otherNormal);
        //
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        //
        if(dotDeg <= 45)
        {
            isCanJump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isCanJump = false;
    }
}