using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter.Counters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounterTests.Writers;
using WordCounterTests.CharReaders;
using WordCounter.CharReaders;

namespace WordCounter.Counters.Tests
{
    [TestClass()]
    public class ParallelCounterTests
    {
        [TestMethod()]
        public void ParallelCounter_CountTest()
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
                var writerMock = new WriterMock();
                CounterBase counter = new ParallelCounter(item, writerMock);
                counter.Count();
                Assert.AreEqual(130, writerMock.Count);
            }

            foreach (var item in testingItems2)
            {
                var WriterMock = new WriterMock();
                CounterBase counter = new ParallelCounter(item, WriterMock);
                counter.Count();
                Assert.AreEqual(54, WriterMock.Count);
            }
        }
    }
}