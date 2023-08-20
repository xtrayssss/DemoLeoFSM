using System.Collections;

namespace Infrastructure.Services.Coroutine
{
    internal interface ICoroutineRunner
    {
        public UnityEngine.Coroutine StartCoroutine(IEnumerator routine);
    }
}