using System;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    MeshRenderer mesh;
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mesh.material.mainTextureOffset += new Vector2(
                speed * Time.deltaTime,
                speed * Time.deltaTime
            );
    }
}
