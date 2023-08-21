using System.Collections;

namespace Infrastructure.Services.Coroutine
{
    public interface ICoroutineRunner
    {
        public UnityEngine.Coroutine StartCoroutine(IEnumerator routine);
    }
}