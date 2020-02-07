using System;
using System.Collections.Generic;
using System.Text;

namespace SolarLabToDoList
{
    public class Task
    {
        public int Number { get; set; } // Номер
        public string Name { get; set; } // Название
        public DateTime Added { get; set; } // Дата добавления
        public DateTime Start { get; set; } // Дата начала
        public DateTime Finish { get; set; } // Дата окончания
        public string Descr { get; set; } // Описание

        public override string ToString() => $"Номер задания: {Number} \r\n" +
            $"Название задания: {Name} \r\n" +
            $"Дата добавления задания: {Added.ToString("d")} \r\n" +
            $"Дата начала выполнения задания: {Start.ToString("d")} \r\n" +
            $"Дата конца выполнения задания: {Finish.ToString("d")} \r\n" +
            $"Описание, заметки: {Descr}".Trim();

    }
}