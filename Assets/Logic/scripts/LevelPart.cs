using UnityEngine;

public class LevelPart : MonoBehaviour
{
    Transform _transform;
    BoxCollider2D _collider;
    float _width;

    protected void Awake()
    {
        _transform = transform;
        _collider = GetComponent<BoxCollider2D>();
        _width = _collider.bounds.size.x;
    }
    public void Move(float xPos)
    {
        _transform.position = new Vector2(xPos + _width, transform.position.y);
        // some animations
    }
    public void Appear()
    {

    }
}
