using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Drawing.Drawing2D;
using CSZoomShape;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLine()
        {
            PointF A = new PointF(0, 0);
            PointF B = new PointF(1, 1);
            Line line = new Line(A, B);
            Assert.AreEqual<double>(1.0d, line.k);
            Assert.AreEqual<double>(0, line.b);

            A = new PointF(1, 0);
            B = new PointF(1, 2);
            line = new Line(A, B);
            Assert.AreEqual<bool>(true, line.IsVertical);
            Assert.AreEqual<double>(1, line.b);

            A = new PointF(0, 0);
            B = new PointF(1, 0);
            line = new Line(A, B);
            Assert.AreEqual<bool>(false, line.IsVertical);
            Assert.AreEqual<double>(0, line.k);
            Assert.AreEqual<double>(0, line.b);
        }
    }
}
