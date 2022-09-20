// adds EdgeCollider2D colliders to screen edges
// only works with orthographic camera

//Includes two different ways of implementation into your project
//One is a method that uses cached fields on Awake() that requires this entire class but is more slightly more efficient (should use this if you plan to use the method in Update())
//The other is a standalone method that doesn't need the rest of the class and can be copy-pasted directly into any project but is slightly less efficient

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cam : MonoBehaviour
    {
        [SerializeField] GameObject corner;
        [SerializeField] GameObject corner2;
        public static int shake = 0;
        private bool isWhite = false;
        //Use this if you want a single function to handle everything (less efficient)
        //You can just ignore/delete the rest of this class if thats the case
        private void Start()
        {

            StandaloneAddCollider();
        }

        void StandaloneAddCollider()
        {
            if (Camera.main == null) { Debug.LogError("Camera.main not found, failed to create edge colliders"); return; }

            var cam = Camera.main;
            if (!cam.orthographic) { Debug.LogError("Camera.main is not Orthographic, failed to create edge colliders"); return; }

            Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
            Vector2 topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
            Vector2 topLeft = new Vector2(bottomLeft.x, topRight.y);
            Vector2 bottomRight = new Vector2(topRight.x, bottomLeft.y);

            // add or use existing EdgeCollider2D
            var edge = GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : GetComponent<EdgeCollider2D>();

            var edgePoints = new[] { bottomLeft, topLeft, topRight, bottomRight };
            edge.points = edgePoints;
            corner2.transform.position = topRight;
            corner.transform.position = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));

        }

        public void ColourFlip()
        {
            isWhite = !isWhite;

            if (isWhite == true)
            {
                Camera.main.backgroundColor = new Color(255, 255, 255);
            }

            else if (isWhite == false)
            {
                Camera.main.backgroundColor = new Color(0, 0, 0);
            }
        }


    }
