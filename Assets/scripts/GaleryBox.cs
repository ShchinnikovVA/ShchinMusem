using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GaleryBox : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Image[] galeryPhotos;
    //private Image[] _GaleryItems;
    [Header("Границы галерееи")]
    public float leftBorder = -2600;
    public float padding = 50;

    public void GaleryScroll()
    {
        for (int i = 0; i < galeryPhotos.Length; i++)
        {
            var _x = galeryPhotos[i].transform.position.x;
            var _y = galeryPhotos[i].transform.position.y;
            galeryPhotos[i].transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
            //print(galeryPhotos[0].rectTransform.sizeDelta.x + " <- width | " + galeryPhotos[0].gameObject.GetComponent<Transform>().localPosition.x + " | " + galeryPhotos[galeryPhotos.Length - 1].gameObject.GetComponent<Transform>().localPosition.x/* + (_GaleryItems[i].rectTransform.rect.width / 2) + padding*/);
            if (galeryPhotos[i].gameObject.GetComponent<Transform>().localPosition.x < leftBorder)
            {
                var _xx = galeryPhotos[galeryPhotos.Length - 1].gameObject.GetComponent<Transform>().localPosition.x + (galeryPhotos[i].rectTransform.sizeDelta.x/* / 2*/) + padding;
                galeryPhotos[i].gameObject.transform.localPosition = new Vector2(_xx, _y);
                for (int j = 0; j < galeryPhotos.Length; j++)
                {
                    if (j + 1 < galeryPhotos.Length)
                    {
                        var _j = galeryPhotos[j];
                        galeryPhotos[j] = galeryPhotos[j + 1];
                        galeryPhotos[j + 1] = _j;
                    }
                }
                //print(_posX);
                
            }
            //print(_x);
        }
        //StartCoroutine("Scrolling")
    }
    //IEnumerator Scrolling()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    GaleryScroll();
    //}
    public void FixedUpdate()
    {
        GaleryScroll();
    }
}
