using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	[SerializeField] float bullet_speed =700f;
    void Update()
    {
        transform.Translate(Vector2.up * bullet_speed * Time.deltaTime);
    }
}