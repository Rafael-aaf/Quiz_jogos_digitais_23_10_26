using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] float initialPositionalX;
    [SerializeField] float finalPositionX;
    [SerializeField] float initialPositionalY;
    [SerializeField] float finalPositionY;
    [SerializeField] GameObject prefabFruit;
    float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3f)
        {
            GameObject newFruit = Instantiate(prefabFruit);
            float xValue = Random.Range(initialPositionalX, finalPositionX);
            float yValue = Random.Range(initialPositionalY, finalPositionY);
            newFruit.transform.position = new Vector3(
                xValue,
                yValue,
                this.transform.position.z
            );
            timer = 0;
        }
    }
}
