using System;
using System.Collections.Generic;
using System.Text;
using BFC.Console.Animals;
using BFC.Console.AppLogic;
using BFC.Console.Presentation;
using Moq;
using NUnit.Framework;

namespace BFC.Tests.Scenarios.Fireman_and_Romantic_love_story
{
    public class WhenRomanticAndFiremanCameIntoForrest
    {
        private BlackForest _blackForest;

        private Mock<IOutputWritter> _presenter;

        [SetUp]
        public void SetUp()
        {
            _presenter = new Mock<IOutputWritter>();
            _blackForest = new BlackForest(_presenter.Object);
        }
         
    }
}
