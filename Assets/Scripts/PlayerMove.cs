using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float sideLerpSpeed;
    [SerializeField] private LayerMask layer;
    private bool isPlaying;

    [SerializeField] private GameObject deathParticle;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.velocity = transform.forward * playerSpeed;
    }

    void FixedUpdate()
    {
        if (isPlaying == true)
        {
            MoveForward();
            MoveSideways();
        }

        if (Input.GetMouseButton(0))
        {
            if (isPlaying == false)
            {
                isPlaying = true;
            }

        }
        Vector3 posX = transform.position;
        posX.x = Mathf.Clamp(transform.position.x, -5.26f, 5.26f);
        transform.position = posX;

    }


    void MoveForward()
    {
        playerRb.velocity = Vector3.forward * playerSpeed;
    }

    void MoveSideways()
    {
        Ray MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(MyRay, out hit, 100, layer))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, transform.position.y, transform.position.z), sideLerpSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            Destroy(other.gameObject);
            Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
            playerSpeed = 0;
            sideLerpSpeed = 0;
        }
  
                
                }


}