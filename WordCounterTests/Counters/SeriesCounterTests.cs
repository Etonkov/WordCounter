using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter.Counters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.CharReaders;
using WordCounter.Writers;

namespace WordCounter.Counters.Tests
{
    [TestClass()]
    public class SeriesCounterTests
    {
        private class ReaderMock : ICharReader
        {
            private readonly char[] Text;
            private readonly int BufferSize;
            private int _position;
            private readonly int TotalSize;

            public ReaderMock(string text, int bufferSize)
            {
                Text = text.ToCharArray();
                TotalSize = Text.Count();
                BufferSize = bufferSize;
                _position = 0;
                IsFinished = false;
            }


            public bool IsFinished { get; private set; }


            public char[] ReadChars()
            {
                char[] c = new char[BufferSize];

                if (!IsFinished)
                {
                    Text.CopyTo(c, _position);
                    _position += BufferSize;
                    IsFinished = _position > TotalSize;
                }
                else
                {
                    throw new InvalidOperationException();
                }

                return c;
            }
        }

        private class WriterMock : ICountWriter
        {
            public long Count { get; private set; }

            public void WriteCount(long count)
            {
                Count = count;
            }
        }

        [TestMethod()]
        public void CountTest()
        {
            // Arrange.
            string text1 =
#region text
@"Не утерпев, я сел записывать эту историю моих первых шагов на жизненном поприще,
тогда как мог бы обойтись и без того. Одно знаю наверно:
никогда уже более не сяду писать мою автобиографию, даже если проживу до ста лет.
Надо быть слишком подло влюбленным в себя, чтобы писать без стыда о самом себе.
Тем только себя извиняю, что не для того пишу, для чего все пишут, то есть не для похвал читателя.
Если я вдруг вздумал записать слово в слово все, что случилось со мной с прошлого года,
то вздумал это вследствие внутренней потребности: до того я поражен всем совершившимся.
Я записываю лишь события, уклоняясь всеми силами от всего постороннего, а главное — от литературных красот;
литератор пишет тридцать лет и в конце совсем не знает, для чего он писал столько лет.";
#endregion

            string text2 =
#region text
@"Можно также определять собственные конфигурации.
Это необходимо, например, для компоновки приложения с несколькими отличающимися версиями.
Раньше из-за проблем, связанных с поддержкой кодировки Unicode в Windows NT, но не в Windows 95,
для многих проектов на С++ было принято создавать две конфигурации — одну для Unicode,
а вторую для MBCS (multibyte character set — набор многобайтных символов).";
            #endregion

            var testingItems1 = new List<ICharReader>()
            {
                { new ReaderMock(text1, 1000)},
                { new ReaderMock(text1, 10)},
                { new ReaderMock(text1, 1)}
            };

            var testingItems2 = new List<ICharReader>()
            {
                { new ReaderMock(text2, 1000)},
                { new ReaderMock(text2, 10)},
                { new ReaderMock(text2, 1)}
            };


            // Act + assert.
            foreach (var item in testingItems1)
            {
                var WriterMock = new WriterMock();
                ICounter counter = new SeriesCounter(item, WriterMock);
                counter.Count();
                Assert.AreEqual(130, WriterMock.Count);
            }

            foreach (var item in testingItems2)
            {
                var WriterMock = new WriterMock();
                ICounter counter = new SeriesCounter(item, WriterMock);
                counter.Count();
                Assert.AreEqual(54, WriterMock.Count);
            }
        }
    }
}