using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    struct Item
    {
        public string Name { get; set; } //자동구현 프로퍼티 생성
        public string Description { get; set; }
    }
    class Inventory
    {
        Item[] items;//텅빈 배열
        public Inventory(int invenSize)//배열 크기 지정
        {
            items = new Item[invenSize];//크기대로 생성
        }

        //인덱스를 인자값으로 주면, 배열 속 해당 아이템 반환해주는 메서드
        public Item GetItemByIndex(int index)
        {
            return items[index];
        }

        //프로퍼티 인벤 그 자체를 외부에 돌려주는 기능
        public Item[] Inven
        {
            get { return items; }
        }

        public Item this[int i] //외부에서 인자로 인덱스를 넘겨줄 것
        {
            get { return items[i]; } //그거 활용해서 반환해줄 내용 적어주기
            set { items[i] = value; } //외부에서 세팅해준 값을 i번쨰 어떻게 활용 잘하기
        }

    }
    class Enemy
    {
        public string Name { get; set; }
    }

    class Ally
    {
        public string Name { get; set; }
    }

    //중복적인 클래스를 만들어야 할 상황에 직면했음. 이럴때 제네릭 생각
    class Troop<T>
    {
        int _count = 0;//현재 생성 유닛 갯수 기억
        T[] army;

        //특정 인덱스를 주면, 거기 있는 요소를 지우는 기능
        //지워지긴 하되, 중간에 ,null이 생기지 않고 유의미한 값들이 연속되게 담기게 하고 싶음

        //총 부대원 반환 가능
        public int Count
        {
            get { return _count; }
            private set { _count = value; } //이런것도 있다 알아두면 좋음. 활용은 굳이
        }


        public void RemoveAt(int index)
        {
            for (int i = index; i < _count - 1; i++)
            {
                army[i] = army[i + 1];
            }

            _count--;
        }

        public void Add(T unit) //인자값 T가 주어지면 그걸 내가 가진 배열에 넣는 기능 제작
        {
            //Array.Resize(ref 원본배열, 새로운크기);
            if (army.Length <= _count)
            {
                Array.Resize(ref army, army.Length * 2);
            }
            army[_count] = unit;
            _count++;
            //Count++;

            //army[_count++] = unit;
        }
        public Troop() //외부에서 인자값 주면 해당 크기로 배열 생성
        {
            army = new T[10];
            _count = 0; 
        }

        //인덱서
        public T this[int i]
        {
            get { return army[i]; }
            set { army[i] = value; }
        }

    }







    internal class Program
    {
        static void Main(string[] args)
        {
            //자료구조 배열
            //크기가 늘었다 줄었다 하는 상황 대처능력이 떨어짐
            //배열에서 특정 내용물을 검색하는 기능도 없음
            //자료를 효율적으로, 그리고 관리하고 싶은 방법에 따라 다르게
            //활용하는 것을 보고 자료구조를 활용한다 이렇게 표현함
            //영어로 컬렉션


            //인덱서
            //가독성이 떨어짐 이럴 떄 인덱서 사용 
            //Inventory myInven = new Inventory(10); //아이템 10개 배열 생성
            ////예) 2번째 이름 불러오기
            //Console.WriteLine(myInven.GetItemByIndex(2).Name); //인덱스 2번째 메서드 사용// item.name
            //Console.WriteLine(myInven.Inven[2].Name); //프로퍼티로 인벤 받아서 사용// 배열.name
            //Console.WriteLine(myInven[2].Name); //클래스 속에 자료구조가 있다면 유용한 인덱서


            //인덱서
            //[접근지정자] [반환형태] this [int i]
            //{
            //    get{return 반환할것;}
            //    set{세팅할값 = value;}
            //}

            //Troop<Ally> myteam = new Troop<Ally>(10);
            ////방법1
            //myteam[2] = new Ally { Name = "Lucina" };
            ////방법2
            //myteam[2] = new Ally();
            //myteam[2].Name = "Lucina";

            //Troop<Enum> enumteam = new Troop<Enum>(10); //10개 짜리 공간만 만듦

            //Troop<Ally> myteam = new Troop<Ally>();
            //Troop<Enemy> myEnum = new Troop<Enemy>();

            //Enemy tempEnemy = new Enemy();
            //tempEnemy.Name = "garon";
            //myEnum.Add(tempEnemy);
            //myEnum.Add(new Enemy { Name = "Kronya"});

            //for (int i = 0; i < myEnum.Count; i++)
            //{
            //    Console.WriteLine(myEnum[i].Name);
            //}

            //myEnum.RemoveAt(1);
            //Console.WriteLine("ddddddddddddddddddddddddddddddd");
            //for (int i = 0; i < myEnum.Count; i++)
            //{
            //    Console.WriteLine(myEnum[i].Name);
            //}

            //Add, Remove, Count

            //List
            //List<int> myFirstList = new List<int>();
            //myFirstList.Add(2);
            //myFirstList.Add(4);
            //myFirstList.Add(8);
            //myFirstList.Add(16);
            //myFirstList.Add(32);


            //foreach (var ele in myFirstList)
            //{
            //    Console.WriteLine(ele);
            //}

            //myFirstList.RemoveAt(2);

            //Console.WriteLine("DDDDDDDDDDDDDDDDDDDDDDDDDDD");

            //foreach (var ele in myFirstList)
            //{
            //    Console.WriteLine(ele);
            //}

            //여러개 리스트
            //List<int> invenRowFirtst = new List<int>();
            //List<int> invenRowSecond = new List<int>();
            //List<int> invenRowThird = new List<int>();

            //자료형[] 배열명 = new 자료형[배열갯수];
            //List<int>[] invenRows = new List<int>[3];//3개로 고정시키고 싶지 않아서 가변화 시킴
            //List<List<int>> twoDim = new List<List<int>>();

            //twoDim.Add(invenRowFirtst); //towDim.[0]
            //twoDim.Add(invenRowSecond); //towDim.[1]
            //twoDim.Add(invenRowThird);  //towDim.[2]

            //twoDim[0].Add(1); //invenRowFirtst.Add(1); 같음
            //twoDim[0][0] = 1;


            //invenRowFirtst[0] = 1;//가능

            ////////////

            //List<int> invenRowFirtst = new List<int>();

            //invenRowFirtst.Add(1);
            //invenRowFirtst.Add(4);
            //invenRowFirtst.Add(7);

            //for (int i = 0; i < 3; i++)
            //{
            //    if(invenRowFirtst[i] == 7)
            //    {
            //        //3번 돌리는데 remove로 인해 크기 1개를 뺌 // 고로 사이즈는 2가 최대임
            //        invenRowFirtst.Remove(7);   
            //    }

            //    Console.WriteLine(invenRowFirtst[i]);

            //}

            /////////////////////////////////

            //Dictionary : 사전 (무엇가를 찾으면 그거에 대한 정보를 줌)
            //특정 키워드를 주면, 그에 해당하는 정보를 가져다 주는 자료구조
            //키값을 주면 값을 반환해줌

            //key와 value로 쓸 자료형을 요구함
            //앞에껀 키값으로 쓸 자료형, 뒤에껀 실제 저장할 값의 자료형
            //Dictionary<int , string> Item = new Dictionary<int, string>();
            ////키에 활용될 수 있는 자료형은 보통은 int, string

            //Item.Add(1, "헤비머신건");
            //Item.Add(5,"회오리폭탄");
            //Item.Add(78,"성스로운부적");

            //Console.WriteLine(Item[1]);  //키값1  // item["헤비머신건"]안됌. 키값value 바꾸면 됌

            ////2의 값이 false면 
            //if(Item.ContainsKey(2) == false)
            //{
            //    Item.Add(2, "크크");
            //}
            //Add, 꺼내는법, ContainsKey 이정도
            /////////////////////////////////////////////////////
            ///

            //stack
            //First in Last Out, Last in First Out
            //FILO, LIFO
            //선입후출, 후입후출

            //스택이 유용하게 쓰일법한 상황
            //웹브라우저에서 뒤로가기(몬스터길들이기)
            //UI창에서 새로운 창이 뜰떄 //예)게임설정 먼저 눌러야 인게임 됌
            //체스같은 게임에서 턴무르기


            //Stack<char> keyInputs = new Stack<char>();

            //while (true)
            //{
            //    var KeyInput123 = Console.ReadKey(true);

            //    keyInputs.Push(KeyInput123.KeyChar);//statck은 밀어넣다의 push로 집어넣음

            //    //집어넣기 위한 Push
            //    //가장 위 요소를 반환하는 동시에 터뜨려 없애는 Pop
            //    //요소를 보기만 하고 없애진 않는 Peek
            //    //Push, Pop, Peek

            //    if (KeyInput123.KeyChar == '0')
            //    {
            //        break;
            //    }

            //}

            //for (int i = 0; i < keyInputs.Count; i++)
            //{
            //    char poped = keyInputs.Pop();
            //    Console.Write(poped);
            //}

            ////Any()

            //while (keyInputs.Any())
            //{
            //    Console.WriteLine(keyInputs.Pop());
            //}

            //STACK 반대
            //Queue<> 큐 : 줄
            //First in First out, FIFO, 선입선출

            Queue<char> keyInputs = new Queue<char>();

            while (true)
            {
                var KeyInput123 = Console.ReadKey(true);

                keyInputs.Enqueue(KeyInput123.KeyChar);//Queue는 줄을 세우다 에서 Enqueue 사용

                if (KeyInput123.KeyChar == '0')
                {
                    break;
                }

            }

            for (int i = 0; i < keyInputs.Count; i++)
            {
                char poped = keyInputs.Dequeue();
                Console.Write(poped);
            }


            //오늘배운거
            //List, Dictionary, Stack, Queue







        }
    }
}
