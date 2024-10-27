using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//NPC����
public abstract class NPC : MonoBehaviour,IInteractable
{
    [SerializeField] private SpriteRenderer _interactSprite;

    private Transform _playerTransform;
    private const float INTERACT_DISTANCE = 2F;
    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        //����e���ڽ���������
        if(Keyboard.current.eKey.wasPressedThisFrame&&IsWithInteractDistance())          
        {
            //���� interact
            Interact();
        }
        //���ھ�����
        if(_interactSprite.gameObject.activeSelf&&!IsWithInteractDistance())
        {
            //�ر�sprite
            _interactSprite.gameObject.SetActive(false);
        }
        //�ھ����ڵ����ǻ�Ծ״̬ ���sprite
        else if(!_interactSprite.gameObject.activeSelf&&IsWithInteractDistance())
        {
            _interactSprite.gameObject.SetActive(true);
        }
    }

    public abstract void Interact();
    //�ڻ���������
    private bool IsWithInteractDistance()
    {
        if(Vector2.Distance(_playerTransform.position,transform.position)< INTERACT_DISTANCE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
