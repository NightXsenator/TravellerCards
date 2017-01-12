using System;
using System.Collections;
using System.Collections.Generic;

namespace TravellerCardsNS
{
    public struct Card
    {
        private string cityA;
        private string cityB;
        //  string dataForTraveller;

        public string CityA
        {
            get
            {
                return cityA;
            }
        }
        public string CityB
        {
            get
            {
                return cityB;
            }
        }

        public Card(string cityA, string cityB)
        {
            this.cityA = cityA;
            this.cityB = cityB;
        }
    }

    public static class CardSorter
    {
        public static Card[] sortCards(Card[] input)
        {
            #region Method Description
            /*
            Исходный массив помещается в список (List), расширенный
            функционал которого позволит провести более наглядную сортировку.
            (Оптимальной с точки зрения производительности структурой данных
            я бы назвал двунаправленный связный список).
            Индексами 0 и i фиксируется блок упорядоченных карточек - вначале это
            самый первый элемент списка. Совершается обход (j) остальной части списка;
            
            1. Начальный город каждого элемента сравнивается с конечным городом
            упорядоченного блока (т.е. конечным городом последнего элемента
            упор. блока). Если одинаковы, то найденный элемент перемещается в конец
            упорядоченного блока, блок становится больше на единицу, начинается
            новый виток обходного цикла.
            
            2. Конечный город элемента сравнивается с началом упор. списка
            (т.е. начальным городом первого эл-та в списке). Если одинаковы, то 
            найденный элемент перемещается в начало упорядоченного блока, 
            блок становится больше на единицу (i++), начинается новый виток обходного
            цикла.
            
            ПРОИЗВОДИТЕЛЬНОСТЬ АЛГОРИТМА:
            
            1.) Сравнения (кол-во)
            ХУДШ.: N^2
            СРЕДН.: [(3/8)*N^2] 
            
            2.) Перестановки
            (1/2)*(N^2)
            
            3.) Итого
            ХУДШ. 3/2*(N^2)
            АЛГОРИТМ С КВАДРАТИЧНОЙ СЛОЖНОСТЬЮ.                    
            */

            #endregion

            if (input.Length == 0) throw new ArgumentNullException("Empty array");
            if (input.Length == 1) return new Card[] { input[0] };

            List<Card> sorting = new List<Card>(input);
            for(int i=0; i<input.Length-1; i++)
                for(int j=i+1; j<input.Length; j++)
                {
                    Card bkp;

                    if (sorting[i].CityB == sorting[j].CityA)
                    {
                        bkp = sorting[j];
                        sorting.RemoveAt(j);
                        sorting.Insert(i + 1, bkp);
                        break;
                    }

                    if (sorting[0].CityA == sorting[j].CityB)
                    {
                        bkp = sorting[j];
                        sorting.RemoveAt(j);
                        sorting.Insert(0, bkp);
                        break;
                    }

                    if (j == input.Length - 1)
                        throw new ArgumentException("Wrong cards");
                }
            
            return(sorting.ToArray());
        }
    }
}
