using UnityEngine;
using System.Collections;

public class bathAppear : MonoBehaviour
{

    private SpriteRenderer img;
    public GetSelectedValue getSelectedValue;
    public ProgressBar progressBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        img = GetComponent<SpriteRenderer>();
    }

    public void ChangeEnabled(int index) {
        if (img != null && index == getSelectedValue.GetValue()) {
            img.enabled = true;
            progressBar.AddPB(-20);
            StartCoroutine(ResetEnabled());
        }
    }

        private IEnumerator ResetEnabled() {
        yield return new WaitForSeconds(3f);
        img.enabled = false;
    }
}
