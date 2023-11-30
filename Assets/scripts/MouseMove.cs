using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.EventSystems;
using DG.Tweening;

public class MouseMove : MonoBehaviour
{
    [Header("Галочка")]
    public GameObject doneImg;
    [Header("Параметры дома")]
    public int myID = 0;
    public int scoreForTheStreet = 2;
    public float moveSpeed = 50f;
    [Header("Карточка дома")]
    public InfoWindowOpen infoWindow;
    [Header("Контролер паузы")]
    public TimerPrompt timerPrompt;
    private bool _isCanDrag = true;
    private bool _isDrag, _isCanTriggered = false;
    private Vector3 _startPosition;
    private Collider2D _isCollision;

    private void Start()
    {
        _isCollision = null;
        doneImg.SetActive(false);
        _startPosition = this.transform.position;
        _startPosition.z = 0;
    }
    private void OnMouseDrag() //Если мышь нажата и можно двигать объект
    {
        if (_isCanDrag && !timerPrompt.GetBoolPause())
        {
            //this.transform.position = Vector3.MoveTowards(this.transform.position, GetMousePosition(), moveSpeed * Time.deltaTime);
            this.transform.position = GetMousePosition();
            _isDrag = true;
            _isCanTriggered = true;
        }
    }
    private void OnMouseUp() //Мышь отжата - возврат картинки
    {
        _isDrag = false;
        if (_isCollision == null)
        {
            MoveObjectToStart(); //Если мы не касаемся коллайдеров
            _isCanTriggered = false;
        }
    }
    private Vector3 GetMousePosition() // Получаем позицию мыши
    {
        var _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePosition.z = 0;
        return _mousePosition;
    }
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.tag == "Street") _isCollision = collision;
        //print(_isCollision + " ВОШЁЛ " + collision.GetComponent<StreetID>().streetID);
        if (collision.tag == "Street" && collision.GetComponent<StreetID>().streetID == myID && !_isDrag && _isCanTriggered)
        {
            MoveObjectToStart();
            collision.GetComponent<StreetID>().doneButton.SetActive(true);
            doneImg.SetActive(true);
            _isCanDrag = false;
            infoWindow.ShowWindow();
        }
        else // Если коллайдер, которого мы касаемся, не подходит по номеру
        {
           if (!_isDrag) MoveObjectToStart();
            _isCanTriggered = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) => _isCollision = null; //Когда мы выходим из коллайдера, обнуляем проверяющее поле
    private void MoveObjectToStart() => this.transform.DOMove(_startPosition, 1f); //Возврат картинки на место
  
}
