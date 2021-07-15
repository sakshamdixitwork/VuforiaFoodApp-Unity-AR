
using UnityEngine;
using UnityEngine.UI;

public class swipe_menu : MonoBehaviour
{
    public GameObject scrollBar;
    float scroll_pos = 0;
    float[] pos;

    private void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for(int i=0; i<pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        
        if(Input.GetMouseButton(0))
        {
            scroll_pos = scrollBar.GetComponent<Scrollbar>().value;

        } else
        {
            for(int i=0; i<pos.Length; i++)
            {
                if(scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }
    }
}
