using System.Collections;  
using UnityEngine;  

namespace ObjectPooling {

	public interface IPoolable{
		void Spawn(Vector3 position, Transform target);
		void DeSpawn (); 
	}
}
