﻿using System.Linq;
using UnityEngine;
using System.Collections;

public class FollowPlayers : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

	// Update is called once per frame
	void Update ()
	{
		var tracked = FindObjectsOfType<TrackedByCamera>();
		Vector3 first_pos = tracked[0].transform.position;
		var num_tracked = 1;
		var tracked_added = new Vector2(0, 0);

		for (var i = 1; i < tracked.Count(); ++i)
		{
			Vector2 diff = tracked[i].transform.position - first_pos;
			tracked_added += diff;
			++num_tracked;
		}

		var camera_half = 2.0f;
		print("half:" + camera_half);
		
		Vector2 first_pos_v2 = first_pos;
		var wanted_pos = first_pos_v2 + (num_tracked == 0 ? new Vector2(0, 0) : (tracked_added * (1.0f/num_tracked)));

		//print("want:" + wanted_pos.x);
		//print("left:" + -455.0f*camera.orthographicSize);
		print(wanted_pos);


		if (wanted_pos.x - camera_half <= -455.0f / 100.0f)
			wanted_pos = new Vector2(-455.0f/100.0f + camera_half, wanted_pos.y);
		else if (wanted_pos.x + camera_half >= 455.0f / 100.0f)
			wanted_pos = new Vector2(455.0f/100.0f - camera_half, wanted_pos.y);

		camera.transform.position = new Vector3(wanted_pos.x, wanted_pos.y, -10.0f);
	}
}