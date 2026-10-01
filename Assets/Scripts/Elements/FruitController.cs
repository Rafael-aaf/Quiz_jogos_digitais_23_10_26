using UnityEngine;

public class FruitController : MonoBehaviour
{

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Collected");
        }
    }

    public void DestroyFruit()
    {
        Destroy(gameObject);
    }

}
