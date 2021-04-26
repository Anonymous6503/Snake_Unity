using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
	public GameObject tailPrefab;
	public GameObject _foodPrefab;
	
	bool ate = false;
	
	public bool isDead = false;
	
	public int _score;
	
	Vector2 dir = Vector2.right;

	public TextMeshProUGUI _text;
	
	public List<Transform> tail = new List<Transform>();

	// Use this for initialization
	void Start ()
	{

		_text = GameObject.FindObjectOfType<TextMeshProUGUI>();
		_text.text = "00";
		InvokeRepeating("Move", 0.3f, 0.3f); 
		Invoke("SpawnFood",0f);

		_score = 0;
	}

	// Update is called once per frame
	void Update () 
	{
		DirectionChange();
		_text.text = _score.ToString("00");
	}

	void Move() {
		if (!isDead) {
			
			Vector2 v = transform.position;
			
			transform.Translate (dir);
			
			if (ate) {
				
				GameObject g = (GameObject)Instantiate (tailPrefab,
					              v,
					              Quaternion.identity);
				
				tail.Insert (0, g.transform);
				
				ate = false;
			} else if (tail.Count > 0) {	
					tail.Last ().position = v;

					
					tail.Insert (0, tail.Last ());
					tail.RemoveAt (tail.Count - 1);
			}
		}
	}

	void DirectionChange()
	{
		if (!isDead) {
			if (Input.GetKey (KeyCode.RightArrow) && dir != Vector2.left)
				dir = Vector2.right;
			else if (Input.GetKey (KeyCode.DownArrow) && dir != Vector2.up)
				dir = -Vector2.up;    
			else if (Input.GetKey (KeyCode.LeftArrow) && dir != Vector2.right)
				dir = -Vector2.right; 
			else if (Input.GetKey (KeyCode.UpArrow) && dir != Vector2.down)
				dir = Vector2.up;
		}
	}

	public void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.name.StartsWith("Food")) {
			
			ate = true;
			
			Destroy(coll.gameObject);
			SpawnFood();
			_score += 1;
		} else { 
			isDead = true;
			Time.timeScale = 0f;
		}
	}

	void SpawnFood()
	{
		GameObject go;
		Vector3 pos = new Vector3(Random.Range(-4f, 4f), Random.Range(-4.5f, 4.5f), 0f);
		
		go = Instantiate(_foodPrefab, pos, Quaternion.identity);
		go.GetComponentInParent<Rigidbody2D>();
	}
	
}
