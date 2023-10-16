using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    public string objectToDetectTag = "PickupHold";
    public LayerMask layersToDetect;
    public Vector2 triggerAreaSize = new Vector2(1f, 1f); // Adjust the size here

    [System.Serializable]
    public class SceneLoadedEvent : UnityEvent<string> { }

    public SceneLoadedEvent onSceneLoaded;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, triggerAreaSize);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsObjectToDetect(other))
        {
            LoadScene();
        }
    }

    private bool IsObjectToDetect(Collider2D other)
    {
        if (string.IsNullOrEmpty(objectToDetectTag))
        {
            return (layersToDetect & (1 << other.gameObject.layer)) != 0;
        }
        else
        {
            return other.CompareTag(objectToDetectTag);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
        if (onSceneLoaded != null)
        {
            onSceneLoaded.Invoke(sceneToLoad);
        }
    }
}