using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUIButton : NetworkBehaviour
{

    [SerializeField] private Button Host;
    [SerializeField] private Button Server;
    [SerializeField] private Button Client;

    private void Awake()
    {
        Host.onClick.AddListener(() => { NetworkManager.Singleton.StartHost();});
        Server.onClick.AddListener(() => { NetworkManager.Singleton.StartServer(); });
        Client.onClick.AddListener(() => { NetworkManager.Singleton.StartClient(); });
    }
}