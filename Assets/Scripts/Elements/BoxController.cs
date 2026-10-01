using UnityEngine;

public class BoxController : MonoBehaviour
{
    Rigidbody2D rigidBody2D;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    async private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            await Awaitable.WaitForSecondsAsync(5f);
            rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
            rigidBody2D.freezeRotation = true;
        }
        
    }
}
