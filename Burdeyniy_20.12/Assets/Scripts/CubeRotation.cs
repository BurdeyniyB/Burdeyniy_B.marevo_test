using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    Quaternion[] orientations = new Quaternion[] {
        Quaternion.LookRotation(Vector3.forward, Vector3.right),
        Quaternion.LookRotation(Vector3.forward, -Vector3.right),
        Quaternion.LookRotation(Vector3.forward, Vector3.up),
        Quaternion.LookRotation(Vector3.forward, -Vector3.up),
        Quaternion.LookRotation(-Vector3.forward, Vector3.right),
        Quaternion.LookRotation(-Vector3.forward, -Vector3.right),
        Quaternion.LookRotation(-Vector3.forward, Vector3.up),
        Quaternion.LookRotation(-Vector3.forward, -Vector3.up),
        Quaternion.LookRotation(Vector3.right, Vector3.forward),
        Quaternion.LookRotation(Vector3.right, -Vector3.forward),
        Quaternion.LookRotation(Vector3.right, Vector3.up),
        Quaternion.LookRotation(Vector3.right, -Vector3.up),
        Quaternion.LookRotation(-Vector3.right, Vector3.forward),
        Quaternion.LookRotation(-Vector3.right, -Vector3.forward),
        Quaternion.LookRotation(-Vector3.right, Vector3.up),
        Quaternion.LookRotation(-Vector3.right, -Vector3.up),
        Quaternion.LookRotation(Vector3.up, Vector3.right),
        Quaternion.LookRotation(Vector3.up, -Vector3.right),
        Quaternion.LookRotation(Vector3.up, Vector3.forward),
        Quaternion.LookRotation(Vector3.up, -Vector3.forward),
        Quaternion.LookRotation(-Vector3.up, Vector3.right),
        Quaternion.LookRotation(-Vector3.up, -Vector3.right),
        Quaternion.LookRotation(-Vector3.up, Vector3.forward),
        Quaternion.LookRotation(-Vector3.up, -Vector3.forward)
    };

    int[,] neighborIndices = new int[24, 4];

    int orientationIndex;
    Quaternion orientation1;
    Quaternion orientation2;
    bool rotating;
    float rotationTimer;

    void Start()
    {
        Quaternion[] rotations = new Quaternion[] {
            Quaternion.AngleAxis(-90, Vector3.up),
            Quaternion.AngleAxis(90, Vector3.up),
            Quaternion.AngleAxis(-90, Vector3.right),
            Quaternion.AngleAxis(90, Vector3.right)
        };

        for (int i = 0; i < 24; ++i) {
            for (int j = 0; j < 4; ++j) {
                var currentOrientation =
                    rotations[j] * orientations[i];
                float maxDot = 0f;
                int neighborIndex = 0;
                for (int k = 0; k < 24; ++k) {
                    float dot = Mathf.Abs(Quaternion.Dot(
                        currentOrientation, orientations[k]));
                    if (dot > maxDot) {
                        maxDot = dot;
                        neighborIndex = k;
                    }
                }
                neighborIndices[i, j] = neighborIndex;
            }
        }

        transform.rotation = orientations[orientationIndex];
    }

    void Update()
    {
        const float rotationTime = .5f;
        if (rotating) {
            rotationTimer += Time.deltaTime;
            if (rotationTimer >= rotationTime) {
                transform.rotation = orientation2;
                rotating = false;
            } else {
                float t = rotationTimer / rotationTime;
                transform.rotation = Quaternion.Slerp(
                    orientation1, orientation2, t);
            }
        } else {
            int rotation = -1;
            if (Input.GetKeyDown("right")) {
                rotation = 0;
            } else if (Input.GetKeyDown("left")) {
                rotation = 1;
            } else if (Input.GetKeyDown("down")) {
                rotation = 2;
            } else if (Input.GetKeyDown("up")) {
                rotation = 3;
            }
            if (rotation != -1) {
                orientationIndex =
                    neighborIndices[orientationIndex, rotation];
                orientation1 = transform.rotation;
                orientation2 = orientations[orientationIndex];
                rotationTimer = 0f;
                rotating = true;
            }
        }
    }
}