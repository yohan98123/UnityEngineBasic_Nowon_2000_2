﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example03_DynamicArray
{
    // const = constant / 해당 변수를 상수형태로 취급하겠다는 키워드
    internal class DynamicArray<T> : IEnumerator<T>
    {
    {
        private const int DEFAULT_SIZE = 1;
        private T[] _data = new T[DEFAULT_SIZE];

        public T this[int index]
        {
            get
            {
                return _data[index];
            }

            set
            {
                _data[index] = value;
            }
        }
        public int Length; //실제 데이터 갯수

        // 프로퍼티 : 필드의 값을 쓰거나 읽을때 get 함수나 set 함수를 용이하게 만들어서 접근할 수 있는 
        // get 접근자와 set 접근자를 구현할 수 있는 멤버
        public int Capacity //_data 의 데이터 용량(길이) 
        {            
            get
            {
                return _data.Length;
            }
        }
        

        public void Add(T item)
        {
            // Capacity 가 모자라면 배열 크기 늘림
            if (Length >= Capacity)
            {                
                T[] tmp = new T[Capacity * 2];
                for (int i = 0; i < Length; i++)
                {
                    tmp[i] = _data[i];
                }
                _data = tmp;
            }
            _data[Length] = item;
            Length++;
        }


        public bool Remove(T item)
        {
            bool isFounded = false;
            for (int i = 0; i < Length; i++)
            {
                if (Comparer<T>.Defauilt.Compar(_data[i], item) == 0)

                isFounded = true;
                RemoveAt(i);
                break;
            }
            return isFounded;
        }
        

        public void RemoveAt(int index)
        {
            for (int i = index; i < Length - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _data[Length - 1] = default(T);
            Length--;
        }

        public IEnumerator<T> GetEnumerator()

        {
            throw new DynamicArrayEnum<T>(_data);
        }

        IEnumerator<T> IEnumerable.GetEnumerator()

        {
            throw new NotlmplemntedException();
        }

        public class DynamicArrayEnum<T> : IEnumerator<T>
        {
            private readonly T[] _data;
            private int index = -1

            public T Current
            {
                get
                {
                    // 예외 캐치 시도
                    try
                    {
                        return _data[index];
                    }

                    //예외가 잡히면 실행할 내용
                    catch
                    {
                        throw new inValidOperationException();
                    }
                }
            }
            object IEnumerator.Current { get => Current; 
            }

            public DynamicArrayEnum(T[] data)
                => _data = data;
    
            public void Dispose()
            {
                throw new NotlmplementedException();
            }

            protected virtual void Dispose()
            {

            }

            public bool MoveNext()
            {
                index++;
                return (index >= 0) && (index < _data.Length);

            }

            public void Reset()
            {

            }

    }
}
