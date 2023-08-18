using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Systems.Movements
{
    public class AsyncTester : MonoBehaviour
    {
        public async void Start()
        {
            InvokeMethod();
            InvokeMethod();
            InvokeMethod();

            await UniTask.Delay(2000, cancellationToken: destroyCancellationToken);
            
            Debug.Log("Main method end");
        }

        private async UniTask InvokeMethod()
        {
            Debug.Log("Method start");

            await UniTask.Delay(2000, cancellationToken: destroyCancellationToken);

            Debug.Log("Method end");
        }
    }
}