using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelEvent : MonoBehaviour
{
    [SerializeField] private Text panelText;
    [SerializeField] private Image iconUI;

    [SerializeField] private Sprite youricon;
    [SerializeField] [TextArea] private string perkPanelText;

    [SerializeField] private bool removeAfterExit = false;
    [SerializeField] private bool disableAfterTime = false;
    [SerializeField] float disableTimer = 1.0f;

    [SerializeField] private Animator notiAnim;
 private BoxCollider objCollider;

    private void Awake()
    {
        objCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(EnableNotification());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && removeAfterExit)
        {
            RemoveNotification();
        }
    }

    IEnumerator EnableNotification()
    {
        objCollider.enabled = false;
        notiAnim.Play("PanelFadeIn");
        panelText.text = perkPanelText;
        iconUI.sprite = youricon;

        if(disableAfterTime)
        {
            yield return new WaitForSeconds(disableTimer);
            RemoveNotification();
        }
    }

    void RemoveNotification()
    {
        notiAnim.Play("PanelFadeOut");
        gameObject.SetActive(false);
    }
}