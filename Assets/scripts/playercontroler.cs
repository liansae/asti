using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class playercontroler : MonoBehaviour
{
   private Vector2 _input;
   private CharacterController _characterController;
   private Vector3 _direction;

   [SerializeField] private float speed;


   private void Awake()
   {
        _characterController = GetComponent <CharacterController>();

   }

   private void Update()
   {
        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);
        _characterController.Move(_direction * speed * Time.deltaTime);
   }

   public void Move(InputAction.CallbackContext context)
   {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);

   }
}
