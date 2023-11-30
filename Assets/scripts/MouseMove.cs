using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.EventSystems;
using DG.Tweening;

public class MouseMove : MonoBehaviour
{
    [Header("�������")]
    public GameObject doneImg;
    [Header("��������� ����")]
    public int myID = 0;
    public int scoreForTheStreet = 2;
    public float moveSpeed = 50f;
    [Header("�������� ����")]
    public InfoWindowOpen infoWindow;
    [Header("��������� �����")]
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
    private void OnMouseDrag() //���� ���� ������ � ����� ������� ������
    {
        if (_isCanDrag && !timerPrompt.GetBoolPause())
        {
            //this.transform.position = Vector3.MoveTowards(this.transform.position, GetMousePosition(), moveSpeed * Time.deltaTime);
            this.transform.position = GetMousePosition();
            _isDrag = true;
            _isCanTriggered = true;
        }
    }
    private void OnMouseUp() //���� ������ - ������� ��������
    {
        _isDrag = false;
        if (_isCollision == null)
        {
            MoveObjectToStart(); //���� �� �� �������� �����������
            _isCanTriggered = false;
        }
    }
    private Vector3 GetMousePosition() // �������� ������� ����
    {
        var _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePosition.z = 0;
        return _mousePosition;
    }
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.tag == "Street") _isCollision = collision;
        //print(_isCollision + " ��ب� " + collision.GetComponent<StreetID>().streetID);
        if (collision.tag == "Street" && collision.GetComponent<StreetID>().streetID == myID && !_isDrag && _isCanTriggered)
        {
            MoveObjectToStart();
            collision.GetComponent<StreetID>().doneButton.SetActive(true);
            doneImg.SetActive(true);
            _isCanDrag = false;
            infoWindow.ShowWindow();
        }
        else // ���� ���������, �������� �� ��������, �� �������� �� ������
        {
           if (!_isDrag) MoveObjectToStart();
            _isCanTriggered = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) => _isCollision = null; //����� �� ������� �� ����������, �������� ����������� ����
    private void MoveObjectToStart() => this.transform.DOMove(_startPosition, 1f); //������� �������� �� �����
  
}
