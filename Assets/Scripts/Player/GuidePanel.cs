using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidePanel : MonoBehaviour, IObserver
{
    public GameObject guidePanel;
    public BoxCollider2D boxCollider;
    void Start()
    {
        if (boxCollider != null)
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }
    }
    public void Update()
    {
        ShowGuidePanel();
    }

    private void ShowGuidePanel()
    {
        guidePanel.SetActive(true);
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
    }
}
