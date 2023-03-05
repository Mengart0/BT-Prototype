using Unity.Services.Authentication;
using System.Threading.Tasks;
using System.Collections.Generic;
using Unity.Services.Core;
using Unity.Services.CloudSave;
using UnityEngine;

public class CloudSaveTrying : MonoBehaviour
{
    private List<string> keys;
    internal async Task Awake()
    {
        await UnityServices.InitializeAsync();
        await SignInAnonymously();
        keys = await CloudSaveService.Instance.Data.RetrieveAllKeysAsync();
    }

    private async Task SignInAnonymously()
    {
        AuthenticationService.Instance.SignedIn += () =>
        {
            var playerId = AuthenticationService.Instance.PlayerId;

            Debug.Log("Signed in as: " + playerId);
        };
        AuthenticationService.Instance.SignInFailed += s =>
        {
            // Take some action here...
            Debug.Log(s);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }
}