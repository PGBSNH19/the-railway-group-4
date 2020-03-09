﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Train_Railway.UnitTest
{
    [TestClass]
    public class TrainTest
    {
        [TestMethod]
        public void TrainSpeed_Speed_MaxSpeed()
        {
            //Arrange
            Train train = new Train();
            train.Speed = 30;
            train.MaxSpeed = 120;
            //Act
            bool result = train.Speed <= train.MaxSpeed;

            //Assert
            Assert.IsTrue(result);

        }
    }
}
