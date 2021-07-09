using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OyuncununCani : NetworkBehaviour {

	public const int can = 150;
	[SyncVar(hook = "CanDegisikligi")]
	private int guncelCan = can;
	public bool dusmanMi;

	public RectTransform CanCubugununGuncelCani;

	private NetworkStartPosition[] dogmaNoktaları;

	// Use this for initialization
	void Start () {

        if (isLocalPlayer)
        {
			dogmaNoktaları = FindObjectsOfType<NetworkStartPosition>();
			Debug.Log(dogmaNoktaları);
            foreach (var item in dogmaNoktaları)
            {
				Debug.Log(item);
            }
        }

	}
	
	// Update is called once per frame
	void Update () {

       


	}

	public void HasarAl(int hasarMiktari)
    {

        if (!isServer)
        {
			return;
        }
		
		guncelCan -= hasarMiktari;


		if(guncelCan <= 0)
        {
            if (dusmanMi)
            {
				Destroy(gameObject);
            }
            else
            {
				guncelCan = can;
				RpcYenidenDogma();
			}
			
        }

		
	
	}

	void CanDegisikligi(int guncelCanDegeri)
    {
		CanCubugununGuncelCani.sizeDelta = new Vector2(guncelCanDegeri, CanCubugununGuncelCani.sizeDelta.y);
	}

	[ClientRpc]
	void RpcYenidenDogma()
    {
        if (isLocalPlayer || isServer)
        {
			//transform.position = Vector3.zero;
			Vector3 OyuncununDogmaNoktasi = transform.position;

			if(dogmaNoktaları !=null && dogmaNoktaları.Length > 0)
            {
				OyuncununDogmaNoktasi = dogmaNoktaları[Random.Range(0, dogmaNoktaları.Length)].transform.position;
            }

			transform.position = OyuncununDogmaNoktasi;
		
		}
    } 

}
