using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class LineWave : MonoBehaviour
{
    public float distancePerVertex = 0.1f;
    public float verticesPerDirection = 10;
    public float VertexLifeTime = 1;

    private LineRenderer _lineRenderer;
    private List<LineWaveNode> _leftVertices;
    private List<LineWaveNode> _rightVertices;
    private Vector3 _transformLeft;         // 局部坐标系的左方向在世界坐标系的方向
    private Vector3 _transformRight;        // 局部坐标系的右方向在世界坐标系的方向

    public class LineWaveNode
    {
        public Vector3 position;
        public float lifeTime;
        public Vector3 direction;
    }
    
    void InitVertices()
    {
        _leftVertices = new List<LineWaveNode>();
        _rightVertices = new List<LineWaveNode>();
        _transformLeft = transform.TransformDirection(Vector3.left);
        _transformRight = transform.TransformDirection(Vector3.right);
        
        for (int i = 0; i < verticesPerDirection; i++)
        {
            _leftVertices.Add(new LineWaveNode()
            {
                position = transform.position + _transformLeft * distancePerVertex * i,
                lifeTime = VertexLifeTime,
                direction = _transformLeft
            });
            _rightVertices.Add(new LineWaveNode()
            {
                position = transform.position + _transformRight * distancePerVertex * i,
                lifeTime = VertexLifeTime,
                direction = _transformRight
            });
        }
    }
    
    void UpdateVertices()
    {
        for (int i = 0; i < _leftVertices.Count; i++)
        {
            _leftVertices[i].position += _leftVertices[i].direction * distancePerVertex * Time.deltaTime;
            _leftVertices[i].lifeTime -= Time.deltaTime;
            if (_leftVertices[i].lifeTime <= 0)
            {
                _leftVertices.RemoveAt(i);
                i--;
            }
        }
        
        for (int i = 0; i < _rightVertices.Count; i++)
        {
            _rightVertices[i].position += _rightVertices[i].direction * distancePerVertex * Time.deltaTime;
            _rightVertices[i].lifeTime -= Time.deltaTime;
            if (_rightVertices[i].lifeTime <= 0)
            {
                _rightVertices.RemoveAt(i);
                i--;
            }
        }
    }
    

    
}
