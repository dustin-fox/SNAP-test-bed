﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {


	public GameObject cubePrefab;
	public GameObject spherePrefab;


	public Vector3 center;
	public Vector3 size;

	public int minCubeSize;
	public int maxCubeSize;

	public int minSphereSize;
	public int maxSphereSize;

	public int numCubes;
	public int numSpheres;



	// Use this for initialization
	void Start () {


		/*Generate Cubes*/
		for(int i = 0; i < numCubes; i++){
			SpawnSquareRandObstacles();
		}

		/*Generate Spheres*/
		for(int i = 0; i < numSpheres; i++){
			SpawnSphereRandObstacles();
		}


	}

	// Update is called once per frame
	void Update () {

	}

	/*
	* Function spawns a sphere of a random size and random position onto the map
	*/
	public void SpawnSphereRandObstacles(){
		int xSize, ySize, zSize; //Holds the scale sizes of each dimension of the sphere
		Vector3 pos; //Will hold a random position vector within the desired volume for the sphere
		GameObject clone; //clone of the Square prefab

		pos = center + new Vector3(Random.Range(-size.x / 2 , size.x/2), Random.Range(-size.y / 2 , size.y/2),Random.Range(-size.z / 2 , size.z/2));

		xSize = Random.Range(minSphereSize, maxSphereSize);
		ySize = Random.Range(minSphereSize, maxSphereSize);
		zSize = Random.Range(minSphereSize, maxSphereSize);

		//spherePrefab.transform.localScale = new Vector3(xSize, ySize, zSize);

		clone = Instantiate(spherePrefab, pos, Quaternion.identity);

		clone.transform.localScale = new Vector3(xSize, ySize, zSize);
	}


	/*
	* Function spawns a cube of a random size and random position onto the map
	*/
	public void SpawnSquareRandObstacles(){
		int xSize, ySize, zSize; //Holds the scale sizes of each dimension of the cube
		Vector3 pos; //Will hold a random position vector within the desired volume for the cube
		GameObject clone; //clone of the Square prefab

		pos = center + new Vector3(Random.Range(-size.x / 2 , size.x/2), Random.Range(-size.y / 2 , size.y/2),Random.Range(-size.z / 2 , size.z/2));

		xSize = Random.Range(minCubeSize, maxCubeSize);
		ySize = Random.Range(minCubeSize, maxCubeSize);
		zSize = Random.Range(minCubeSize, maxCubeSize);

		//cubePrefab.transform.localScale = new Vector3(xSize, ySize, zSize);

		clone = Instantiate(cubePrefab, pos, Quaternion.identity);

		clone.transform.localScale = new Vector3(xSize, ySize, zSize);

	}

	/*
	* Function that creates a transparent cube that contains the volume where obstacles can spawn
	*/
	void OnDrawGizmosSelected(){
		Gizmos.color = new Color(1,0,0,0.5f);
		Gizmos.DrawCube(transform.localPosition + center, size);


	}
}
