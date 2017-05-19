using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WordCounter.CharReaders;
using WordCounterTests.CharReaders;
using WordCounterTests.Writers;

namespace WordCounter.Counters.Tests
{
    [TestClass()]
    public class IgnoreDigitCounterTests
    {
        [TestMethod()]
        public void CountTest()
        {
            // Arrange.
            string text1 =
            #region text
@"3453  34533g g3434 363436435645 --=3 3453b453 \n\r 3 3453  34533g g3434 363436435645 --=3 3453b453 \n\r 3
3453  34533g g3434 363436435645 --=3 3453b453 \n\r 3 3453  34533g g3434 363436435645 --=3 3453b453 \n\r 3
3453  34533g g3434 363436435645 --=3 3453b453 \n\r 3 3453  34533g g3434 363436435645 --=3 3453b453 \n\r 3";
            #endregion

            string text2 =
            #region text
@"Можно также определять65456 456456собственные конфигура4564ции.456/
Это необходимо, 44564 например, для компоновки приложения с несколькими отличающимися версиями.
Раньше из-за проблем, связанных с поддержкой кодировки Unicode в Windows NT, но не в Windows 95,
для многих проектов на С++ было принято создавать две конфигурации — одну для Unicode,
а вторую для MBCS (multibyte character set — набор многобайтных символов).
Можно также определять65456 456456собственные конфигура4564ции.456/
Это необходимо, 44564 например, для компоновки приложения с несколькими отличающимися версиями.
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
                CounterBase counter = new IgnoreDigitCounter(item, writerMock);
                counter.Count();
                Assert.AreEqual(36, writerMock.Count);
            }

            foreach (var item in testingItems2)
            {
                var WriterMock = new WriterMock();
                CounterBase counter = new IgnoreDigitCounter(item, WriterMock);
                counter.Count();
                Assert.AreEqual(106, WriterMock.Count);
            }
        }
    }
}