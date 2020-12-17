using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrøveEksamenREST.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using ModelLib;

namespace PrøveEksamenREST.Managers.Tests
{
    [TestClass()]
    public class MeasurementManagerTests
    {
        public static List<Measurement> _testMeasurements;
        public static DateTime df;
        public static MeasurementManager _manager;

        [ClassInitialize()]
        static public void init(TestContext testContext)
        {
            df = new DateTime(2000,1,1,0,0,0);
            _testMeasurements = new List<Measurement>()
            {
                new Measurement(1,1,2,3,df),
                new Measurement(2,10,20,30,df),
                new Measurement(3,100,200,300,df),
                new Measurement(4,1,20,300,df),
                new Measurement(69,1000,1000,1000,df)
            };
        }
        MeasurementManager manager = new MeasurementManager(true);
        [TestMethod()]
        public void GetAllTest()
        {
            int count = manager.GetAll().Count;

            Assert.AreEqual(_testMeasurements.Count, count);
        }

        [TestMethod()]
        public void GetOneTest()
        {
            Measurement Meas = manager.GetOne(1);
            Assert.AreEqual(_testMeasurements[0].Id,Meas.Id);
        }

        [TestMethod()]
        public void AddMeasurementTest()
        {
            manager.DeleteMeasurement(69);
            int count = manager.GetAll().Count;
            Measurement addMeasurement = new Measurement(69,1000,1000,1000, df);
            manager.AddMeasurement(addMeasurement);
            Assert.AreEqual(count + 1, manager.GetAll().Count);
            
        }

        [TestMethod()]
        public void DeleteMeasurementTest()
        {
            Measurement addMeasurement = new Measurement(79, 1000, 1000, 1000, df);
            manager.AddMeasurement(addMeasurement);
            int count = manager.GetAll().Count;
            manager.DeleteMeasurement(79);

            Assert.AreEqual(count-1,manager.GetAll().Count);
        }
    }
}