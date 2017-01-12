using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravellerCardsNS;

namespace CardsTesting
{
    [TestClass]
    public class CardsTestClass
    {
        [TestMethod]
        public void SortAlgorhytmTest()
        {
            Card[] test = new Card[]
            {
                new Card("Vienna", "Amsterdam"),
                new Card("Berlin", "Vienna"),
                new Card("Tallin", "Kirov"),
                new Card("Moscow", "Berlin"),
                new Card("Amsterdam", "Tallin")
            };

            test = CardSorter.sortCards(test);
            string chkval = test[0].CityA;
            bool sortIsCorrect = true;
            foreach (Card t in test)
            {
                if (t.CityA != chkval) { sortIsCorrect = false; break; }
                chkval = t.CityB;
            }

            Assert.IsTrue(sortIsCorrect, "Sort is incorrect");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReactionOnEmptyArrayTest()
        {
            Card[] test = new Card[1];
            CardSorter.sortCards(test);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReactionOnWrongCardsCollectionTest()
        {
            Card[] test = new Card[]
            {
                new Card("Moscow", "Tallin"),
                new Card("Peter", "Tallin")
            };
            CardSorter.sortCards(test);
        }

    }
}
