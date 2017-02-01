using UnityEngine;

// Daniel Letscher

/// <summary>
/// Destroys wayward objects that run into it.
/// </summary>
public class WallOfDeath : MonoBehaviour {
    internal void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag.Equals("Tank"))
        {
            ScoreManager.IncreaseScore(obj.gameObject, -50);
        }
        Destroy(obj.gameObject);
    }
}
