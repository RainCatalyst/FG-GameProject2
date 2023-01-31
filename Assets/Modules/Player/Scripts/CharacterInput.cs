using UnityEngine;

namespace SpaceGame
{
    public class CharacterInput : MonoBehaviour
    {
        public void SetPlayerIndex(int index)
        {
            string indexName = (index + 1).ToString();
            horizontalAxis = "Horizontal" + indexName;
            horizontalAxisJoy = "HorizontalJoy" + indexName;
            verticalAxis = "Vertical" + indexName;
            verticalAxisJoy = "VerticalJoy" + indexName;
        }

        public Vector2 GetAxis()
        {
            Vector2 axis;
            axis.x = Input.GetAxisRaw(horizontalAxis) + Input.GetAxisRaw(horizontalAxisJoy);
            axis.y = Input.GetAxisRaw(verticalAxis) + Input.GetAxisRaw(verticalAxisJoy);
            return axis.normalized;
        }
        
        private void Awake()
        {
            SetPlayerIndex(0);
        }

        private string horizontalAxis;
        private string horizontalAxisJoy;
        private string verticalAxis;
        private string verticalAxisJoy;
        
        private int playerIndex;
    }
}