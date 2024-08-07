using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    // Update is called once per frame
    private void LateUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float h = Input.GetAxis(InputMovement.HORIZONTAL);
        float v = Input.GetAxis(InputMovement.VERTICAL);
        Vector3 move = transform.right * h + transform.forward * v;
        controller.Move(move * speed * Time.deltaTime);
    }
}
