using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DusmanYaratma : NetworkBehaviour {

	public GameObject dusmaninPrefabi;
	public int toplanDusmanSayisi = 7;

	public override void OnStartServer()
    {
		for(int i = 0; i<toplanDusmanSayisi; i++)
        {
            Vector3 dogmaPozisyonu = new Vector3(Random.Range(-7, 7), 0f, Random.Range(-7, 7));
            Quaternion dogmaDonus = Quaternion.Euler(0f, Random.Range(0f, 180f), 0f);
            GameObject dusman = Instantiate(dusmaninPrefabi, dogmaPozisyonu, dogmaDonus) as GameObject;
            NetworkServer.Spawn(dusman);
        }
    }
}
