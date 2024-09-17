using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.EditorCoroutines.Editor;
using UnityEngine;

namespace Obstacles.Sequence
{
    public class MovementSequence
    {
        private readonly IReadOnlyList<IMovementSequenceTerm> _terms;
        private readonly CoroutineExecutor _coroutineExecutor;

        private int _currentTermIndex;
        private Coroutine _executableSequence;

        public MovementSequence(IReadOnlyList<IMovementSequenceTerm> terms, CoroutineExecutor coroutineExecutor)
        {
            if (terms is null || terms.Count == 0)
                throw new ArgumentException(nameof(terms));
            _terms = terms;
            _coroutineExecutor = coroutineExecutor;
            _currentTermIndex = 0;
        }

        public void StartProcessing() => 
            _executableSequence = _coroutineExecutor.Start(ChangeBetweenStates());

        public void Stop()
        {
            _coroutineExecutor.Stop(_executableSequence);
        }

        private IEnumerator ChangeBetweenStates()
        {
            while (true)
            {
                IEnumerator termCorutine = _terms[_currentTermIndex].GetSequenceTermCoroutine();
                
                yield return _coroutineExecutor.Start(termCorutine);
                
                _currentTermIndex = GetNextIndex(_currentTermIndex);
            }
        }

        private int GetNextIndex(int currentIndex) => 
            (currentIndex + 1) % _terms.Count;
    }
}