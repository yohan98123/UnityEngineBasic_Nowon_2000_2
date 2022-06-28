using System;
using System.Collections.Generic;
namespace GenericCollections
{
    // Generic : 일반화
    // 다양한 자료형에 대해서 유동적으로 갖다쓸수 있도록 만드는 형태    
    internal class Program
    {
        static void Main(string[] args)
        {
            // List
            // ------------------------------------------------------------------------------
            List<int> list_int = new List<int>();
            List<float> list_float = new List<float>();
            List<List<int>> list_list_int = new List<List<int>>();

            // 추가
            list_int.Add(0);
            list_float.Add(1.0f);
            list_list_int.Add(list_int);
            list_list_int.Add(new List<int>());

            // 삭제
            list_int.Remove(0);
            list_list_int.RemoveAt(1);

            // 검색

            //list_int.Find(x => x == 0);
            list_int.Contains(0);
            //---------------------------------------------------------------------------------
            // LinkedList
            // 단방향 : Singly linkedlist
            // 양방향 : Doubly linkedlist
            // 추가 : Addfirst(), AddLast(), Addafter(), AddBefore()
            // 탐색 : Find(), FindLast().Contains()
            // 삭제 : Remove(value), Remove(Node), Removefirst(), RemoveLast()
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddLast(0);
            linkedList.AddFirst(1);
            linkedList.AddBefore(linkedList.Find(0), 3);
            Console.WriteLine(linkedList.First);
            linkedList.RemoveLast();
            //-----------------------------------------------------------------------------------
            // Dictionary =.net 제네릭형태
            // Hash : 고유키값
            // Hash 함수 : Hash를 뽑아내는 함수
            // HashTable : key(죄수번호), value(죄수이름)
            // 문자열 키값으로 해시를 뽑아내는 해시함수 구현 방식
            // 1. 입력 문장열의 각 문자들을 정수형태(ascii)로  전부 더한다.(부가적으로 충돌(ascii 코드의 합이 같음)을 줄이기 위해서
            //    자릿수를 곱하거나 자릿수의 승수를 곱하는등의 연산을 추가 할 수 있다.
            // 2. 1의 값에 해시테이블 크기로 모듈러연산을 한다.
            // 3. 2의 결과를 해시로 반환한다.
            // 4. 3에서 오류(ascii코드의 합이 같음)가 있을때 해결방법
            // 4 - 1. 체이닝 : hash 충돌이 일어난 value 들을 linkedlist 형태로 관리하는 방법. value -> Bucket(value 값이 여러개)
            // 4 - 2. 오픈어드레싱 : Linear probing 같은 키를 가진 값을이 있을때 배열 Quadratic Probing 

            //__________________________________________________________________________________
            // Queue

            //----------------------------------------------------------------------------------
            // Stack

        }
    }
}
