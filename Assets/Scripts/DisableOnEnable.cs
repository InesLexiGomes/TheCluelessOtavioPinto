using UnityEngine;

public class DisableOnEnable : MonoBehaviour
{
    private void OnEnable() {
        gameObject.SetActive(false);
    }
}
