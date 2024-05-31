using UnityEngine;
using UnityEngine.UI;

public class ActiveReload : MonoBehaviour
{
    public Image reloadBar;
    public float reloadTime = 2.0f;
    public float perfectWindowStart = 0.4f;
    public float perfectWindowEnd = 0.6f;
    public float goodWindowStart = 0.2f;
    public float goodWindowEnd = 0.8f;

    private float reloadProgress = 0.0f;
    private bool isReloading = false;

    void Update()
    {

        // Tap = Reload
            //The feature is called Reload because it is inspired by a reload system, you tap when the trigger overlaps the window in the bar which ensues a reload.

        if (isReloading)
        {
            reloadProgress += Time.deltaTime / reloadTime;
            reloadBar.fillAmount = reloadProgress;

            // Handle PC input
            if (Input.GetKeyDown(KeyCode.R))
            {
                StopReload();
            }

            // Handle mobile input
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                StopReload();
            }

            if (reloadProgress >= 1.0f)
            {
                isReloading = false;
                reloadBar.gameObject.SetActive(false);
                // Tap failed, reset window state
            }
        }
    }

    public void StartReload()
    {
        if (!isReloading)
        {
            isReloading = true;
            reloadProgress = 0.0f;
            reloadBar.gameObject.SetActive(true);
        }
    }

    private void StopReload()
    {
        isReloading = false;
        reloadBar.gameObject.SetActive(false);

        if (reloadProgress >= perfectWindowStart && reloadProgress <= perfectWindowEnd)
        {
            // Perfect reload
            Debug.Log("Perfect Tap");
            // Apply faster reload
        }
        else if (reloadProgress >= goodWindowStart && reloadProgress <= goodWindowEnd)
        {
            // Good reload
            Debug.Log("Good Tap");
            // Apply faster reload without damage boost
        }
        else
        {
            // Failed reload
            Debug.Log("Failed Tap");
            // Apply longer reload penalty
        }
    }
}
