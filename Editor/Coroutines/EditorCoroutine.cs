using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// A coroutine that can run outside of play mode.
    /// </summary>
    public class EditorCoroutine
    {
        /// <summary>
        /// The coroutine we are currently running.
        /// </summary>
        private IEnumerator _coroutine = null;

        /// <summary>
        /// The instruction of the current element of the enumerator's collection.
        /// </summary>
        private ICoroutineYield _currentYield = null;

        /// <summary>
        /// The name of the coroutine we are currently running.
        /// </summary>
        private string _methodName = string.Empty;

        /// <summary>
        /// Constructs EditorCoroutine from a traditional coroutine.
        /// </summary>
        /// <param name="coroutine"></param>
        private EditorCoroutine(IEnumerator coroutine)
        {
            _coroutine = coroutine;
            _currentYield = new YieldDefault();
            _methodName = _coroutine.ToString();
        }

        /// <summary>
        /// Creates an editor coroutine and starts it.
        /// </summary>
        /// <param name="coroutine"></param>
        /// <returns>The created editor coroutine.</returns>
        public static EditorCoroutine Start(IEnumerator coroutine)
        {
            EditorCoroutine editorCoroutine = new EditorCoroutine(coroutine);
            editorCoroutine.Start();
            return editorCoroutine;
        }

        /// <summary>
        /// Starts coroutine.
        /// </summary>
        private void Start()
        {
            EditorApplication.update += EditorUpdate;
        }

        /// <summary>
        ///  Editor update tick.
        /// </summary>
        private void EditorUpdate()
        {
            if (!_currentYield.IsDone())
            {
                return;
            }

            if (!MoveNext())
            {
                Stop();
            }
        }

        /// <summary>
        /// Stops coroutine.
        /// </summary>
        private void Stop()
        {
            EditorApplication.update -= EditorUpdate;

            _currentYield = null;
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns></returns>
        private bool MoveNext()
        {
            if (_coroutine.MoveNext())
            {
                return Process();
            }
            return false;
        }

        /// <summary>
        /// Process current yield instruction.
        /// </summary>
        /// <returns></returns>
        private bool Process()
        {
            object yield = _coroutine.Current;

            if (yield == null)
            {
                _currentYield = new YieldDefault();
            }
            else if (yield is AsyncOperation)
            {
                _currentYield = new YieldAsync { webRequest = (AsyncOperation)yield};
            }
            else
            {
                var msg = $"<{_methodName}> yielded an unknown or unsupported type ({yield.GetType()})";
                Debug.LogException(new Exception(msg), null);

                _currentYield = new YieldDefault();
            }

            return true;
        }

        #region Yields

        /// <summary>
        /// Defines generic yield instruction's entry point.
        /// </summary>
        public interface ICoroutineYield
        {
            bool IsDone(float deltaTime = 0f);
        }

        /// <summary>
        /// Default yield instruction.
        /// </summary>
        struct YieldDefault : ICoroutineYield
        {
            public bool IsDone(float deltaTime = 0f)
            {
                return true;
            }
        }

        /// <summary>
        /// Yield instruction for asynchronous operations.
        /// e.g UnityWebRequest
        /// </summary>
        struct YieldAsync : ICoroutineYield
        {
            public AsyncOperation webRequest;

            public bool IsDone(float deltaTime = 0f)
            {
                return webRequest.isDone;
            }
        }

        #endregion Yields
    }
}
