using UnityEngine;

public class DestroyOnEnable : MonoBehaviour
{
    private void OnEnable() {
        gameObject.SetActive(false);
    }
}
