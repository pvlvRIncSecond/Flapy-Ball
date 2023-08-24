using System;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public Action OnCollide { get; set; }

    private void OnCollisionEnter2D(Collision2D other) => 
        OnCollide?.Invoke();

}
