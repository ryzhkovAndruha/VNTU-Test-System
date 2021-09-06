using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNTU_Test.Entities;

namespace VNTU_Test
{
    public static class TestData
    {
        public static List<Test> Tests { get; set; }
        
        public static void CreateTestData()
        {
            CreateTests();
        }

        private static void CreateTests()
        {
            Tests = new List<Test>()
            {
                new Test
                {
                    Name = "Основы C#",
                    Questions = new List<Question>(CreateQuestions()),
                    CountOfCorrectAnswers = 0,
                    CurrentQuestion = 0
                }
            };
        }

        private static List<Question> CreateQuestions()
        {
            return new List<Question>()
            {
                new Question
                {
                    Title = "Принципы полиморфизма",
                    Description = "Укажите основные принципи полиморфизма (Несколько вариантов)",
                    Answers = new List<Answer>()
                    {
                        new Answer
                        {
                            Id="1",
                            Text = "Инкапсуляция",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            Id="2",
                            Text = "Возможность создавать статические классы",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            Id="3",
                            Text = "Полиморфизм",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            Id="4",
                            Text = "Наследование",
                            IsCorrect = true
                        }
                    }
                },

                new Question
                {
                    Title = "Функции string",
                    Description = "Какая функция корректно сравнивает две подстроки?",
                    Answers = new List<Answer>()
                    {
                        new Answer
                        {
                            Id="1",
                            Text = "String.Equal(\"hi\", \"hello\");",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            Id="2",
                            Text = "String.Compare(\"hi\", \"hello\");",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            Id="3",
                            Text = "String.Check(\"hi\", \"hello\");",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            Id="4",
                            Text = "String.Match(\"hi\", \"hello\");",
                            IsCorrect = false
                        }
                    }

                },

                new Question
                {
                    Title = "Типы данных",
                    Description = "Какие типы переменных существуют?",
                    Answers = new List<Answer>()
                    {
                        new Answer
                        {
                            Id="1",
                            Text = "int, char, bool, float, double",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            Id="2",
                            Text = "Все перечисленные",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            Id="3",
                            Text = "int, char, bool, float, double, uint, short",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            Id="4",
                            Text = "Ни один из них",
                            IsCorrect = false
                        }
                    }

                },

                 new Question
                 {
                    Title = "Полиморфизм",
                    Description = "Что такое перегрузка методов?",
                    Answers = new List<Answer>()
                    {
                        new Answer
                        {
                            Id="1",
                            Text = "Использование одного имени для разных методов",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            Id="2",
                            Text = "Передача слишком больших данных в функцию",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            Id="3",
                            Text = "Передача слишком большого файла через return",
                            IsCorrect = false
                        },
                    }

                 },

                 new Question
                 {
                    Title = "Циклы",
                    Description = "Какие циклы существуют в языке C#?",
                    Answers = new List<Answer>()
                    {
                        new Answer
                        {
                            Id="1",
                            Text = "for, while, do while, foreach",
                            IsCorrect = true
                        },
                        new Answer
                        {
                            Id="2",
                            Text = "for, while, do while",
                            IsCorrect = false
                        },
                        new Answer
                        {
                            Id="3",
                            Text = "for, while, foreach",
                            IsCorrect = false
                        },
                    }

                 }
            };
        }

    }
}
