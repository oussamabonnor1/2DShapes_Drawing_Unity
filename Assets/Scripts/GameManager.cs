using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	List<Vector2> positions;
	Vector2 position;
	// Use this for initialization
	void Start () {
		positions = new List<Vector2>();   
	}

	public void Update(){
		if(Input.GetMouseButtonDown(0)){
			position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			positions.Add(position);
			GetComponent<LineRenderer>().SetVertexCount(positions.Count);
			GetComponent<LineRenderer>().SetPosition(positions.Count-1,position);
		}
		if(Input.GetMouseButtonDown(1)){
			Color color = Random.ColorHSV();
			MakeShape(positions.ToArray(),color);
			
		}
	}

	public void MakeShape(Vector2[] vertices2D, Color color){
        var vertices3D = System.Array.ConvertAll<Vector2, Vector3>(vertices2D, v => v);
        var triangulator = new Triangulator(vertices2D);
        var indices = triangulator.Triangulate();
        var colors = 
        Enumerable.Range(0, vertices3D.Length)
        	.Select(i => color)
        	.ToArray();
        var mesh = new Mesh{
        	vertices = vertices3D,
        	triangles = indices,
        	colors = colors
        };
        GameObject gameObject = new GameObject();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        if(gameObject.GetComponent<MeshRenderer>() == null) gameObject.AddComponent<MeshRenderer>().material = new Material(Shader.Find("Sprites/Default"));
        if(gameObject.GetComponent<MeshFilter>() == null)gameObject.AddComponent<MeshFilter>().mesh = mesh;
        if(gameObject.GetComponent<Rigidbody2D>() == null)gameObject.AddComponent<Rigidbody2D>().mass = 700f;
        if(gameObject.GetComponent<PolygonCollider2D>() == null) gameObject.AddComponent<PolygonCollider2D>().points = positions.ToArray();
        GetComponent<LineRenderer>().SetVertexCount(0);
        positions = new List<Vector2>();
	}
}
