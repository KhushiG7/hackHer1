using UnityEngine;
using System.Collections;

public class bathAppear : MonoBehaviour
{

    private SpriteRenderer img;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        img = GetComponent<SpriteRenderer>();
    }

    public void ChangeEnabled() {
        if (img != null) {
            img.enabled = true;
            StartCoroutine(ResetEnabled());
        }
    }

        private IEnumerator ResetEnabled() {
        yield return new WaitForSeconds(3f);
        img.enabled = false;
    }
}
