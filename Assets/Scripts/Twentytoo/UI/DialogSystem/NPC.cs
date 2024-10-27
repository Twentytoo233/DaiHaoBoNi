using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//NPC基类
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
        //按下e且在交互距离内
        if(Keyboard.current.eKey.wasPressedThisFrame&&IsWithInteractDistance())          
        {
            //交互 interact
            Interact();
        }
        //不在距离内
        if(_interactSprite.gameObject.activeSelf&&!IsWithInteractDistance())
        {
            //关闭sprite
            _interactSprite.gameObject.SetActive(false);
        }
        //在距离内但不是活跃状态 则打开sprite
        else if(!_interactSprite.gameObject.activeSelf&&IsWithInteractDistance())
        {
            _interactSprite.gameObject.SetActive(true);
        }
    }

    public abstract void Interact();
    //在互动距离内
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
