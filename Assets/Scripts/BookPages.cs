using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPages : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> pages;
    private int currentPage = 0;
    private int previousPage;
    [SerializeField]
    private GameObject leftButton;
    [SerializeField]
    private GameObject rightButton;

    void Update()
    {
        if (currentPage != previousPage)
        {
            foreach (var page in pages)
            {
                page.SetActive(false);
            }

            pages[currentPage].SetActive(true);
            previousPage = currentPage;
        }
    }

    public void FlipRight()
    {
        currentPage++;
    }

    public void FlipLeft()
    {
        currentPage--;
    }

    public void UpdateButtons()
    {
        if (currentPage == 0)
            leftButton.SetActive(false);
        else
            leftButton.SetActive(true);
        if (currentPage == pages.Count - 1)
            rightButton.SetActive(false);
        else 
            rightButton.SetActive(true);
    }
}
