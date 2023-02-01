using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class StackClass
    {
        /// Стек
            
            Stack <string> paragr = new Stack<string>();
        




        /// Коллекция хранимых данных.

        /*  private List<T> _items = new List<T>();

          /// Количество элементов.
          public int Count => _items.Count;

          /// Добавить данные в стек.
          /// <param name="item"> Добавляемые данные. </param>
          public void Push( T item )
          {
              // Проверяем входные данные на пустоту.
              if (item == null)
              {
                  throw new ArgumentNullException(nameof(item));
              }

              // Добавляем данные в коллекцию элементов.
              _items.Add(item);
          }

          /// Получить верхний элемент стека с удалением.
          /// <returns> Элемент данных. </returns>
          public T Pop()
          {
              // Получаем верхний элемент.
              var item = _items.LastOrDefault();

              // Если элемент пуст, то сообщаем об ошибке.
              if (item == null)
              {
                  throw new NullReferenceException("Стек пуст. Нет элементов для получения.");
              }

              // Удаляем последний элемент из коллекции.
              _items.RemoveAt(_items.Count - 1);

              // Возвращаем полученный элемент.
              return item;
          }

          /// Прочитать верхний элемент стека без удаления.
          /// <returns> Элемент данных.
          public T Peek()
          {
              // Получаем верхний элемент.
              var item = _items.LastOrDefault();

              // Если элемент пуст, то сообщаем об ошибке.
              if (item == null)
              {
                  throw new NullReferenceException("Стек пуст. Нет элементов для получения.");
              }

              return item;
          }
        */


    }
}
