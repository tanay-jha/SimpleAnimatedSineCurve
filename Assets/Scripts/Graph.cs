using UnityEngine; //this calls the UnityEngine package.

public class Graph : MonoBehaviour {
	public Transform pointPrefab; //this will contain the transformation properties of the object.
	Transform[] points;
	[Range(10,100)] public int resolution = 10; //defines the number of cubes in the presentation of the graph. Editable in the editor.
	void Awake() {
		float step = 2f / resolution;
		Vector3 scale = (Vector3.one)* step;
		Vector3 position;
		position.z = 0f;
		position.y = 0f;
		points = new Transform[resolution];
		for (int iterator = 0; iterator < resolution; iterator++) {
			Transform point = Instantiate (pointPrefab);
			position.x = (((iterator+0.5f)* step) - 1f);

			//position.y = position.x*position.x*position.x;  //this can be expressed in the form of y= f(x).

			point.localPosition = position;
			point.localScale = scale;
			point.SetParent (transform, false);
			points [iterator] = point;
		}
	}

	void Update() {
		for (int iterator = 0; iterator < points.Length; iterator++) {
			Transform point = points [iterator];
			Vector3 position = point.localPosition;
			position.y = Mathf.Sin (Mathf.PI * (position.x+ Time.time));
			point.localPosition = position;
		}
	}
}