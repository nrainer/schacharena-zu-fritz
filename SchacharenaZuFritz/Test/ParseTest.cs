using System;
using System.IO;
using System.Reflection;

using NUnit.Framework;
using SchacharenaZuFritz.Logic.Impl;

namespace SchacharenaZuFritz.Test
{
	[TestFixture]
	public class ParseTest
	{
		[Test]
		public void Test1()
		{
			TestInternal(1);
		}
		
		[Test]
		public void Test2()
		{
			TestInternal(2);
		}
		
		[Test]
		public void Test3()
		{
			TestInternal(3);
		}
		
		private void TestInternal(int fileIndex)
		{
			string folder = "Test/";
			
			string inputPath = folder + "input" + fileIndex + ".txt";
			string input = File.ReadAllText(inputPath);
			
			string expectedPath = folder + "expected" + fileIndex + ".txt";
			string expected = File.ReadAllText(expectedPath);
			
			SchacharenaToFritz converter = new SchacharenaToFritz();
			string actual = converter.Convert(input);
			Console.WriteLine(actual);
			Assert.AreEqual(expected.Trim(), actual.Trim());
		}
	}
}
